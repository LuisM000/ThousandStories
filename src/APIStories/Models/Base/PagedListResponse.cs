using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Ninject.Infrastructure.Language;

namespace APIStories.Models.Base
{
    public class PagedListResponse<T>
    {
        public int PageCount { get; }
        public int TotalItemCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
        public bool IsFirstPage { get; }
        public bool IsLastPage { get; }
        public int FirstItemOnPage { get; }
        public int LastItemOnPage { get; }
        public IEnumerable<T> Items { get; }

        public PagedListResponse(IPagedList<T> pagedList)
        {
            this.PageCount = pagedList.PageCount;
            this.TotalItemCount = pagedList.TotalItemCount;
            this.PageNumber = pagedList.PageNumber;
            this.PageSize = pagedList.PageSize;
            this.HasPreviousPage = pagedList.HasPreviousPage;
            this.HasNextPage = pagedList.HasNextPage;
            this.IsFirstPage = pagedList.IsFirstPage;
            this.IsLastPage = pagedList.IsLastPage;
            this.FirstItemOnPage = pagedList.FirstItemOnPage;
            this.LastItemOnPage = pagedList.LastItemOnPage;
            this.Items = pagedList.ToEnumerable();
        }

        

    }
}