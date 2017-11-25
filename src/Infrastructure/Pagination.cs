
using System;

namespace Infrastructure
{
    public class Pagination
    {
        public Pagination(int pageNumber, int rowsPerPage)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            if (rowsPerPage < 1)
                throw new ArgumentOutOfRangeException(nameof(rowsPerPage), rowsPerPage, "RowsPerPage cannot be less than 1.");

            this.PageNumber = pageNumber;
            this.RowsPerPage = rowsPerPage;
        }

        public int PageNumber { get; }
        public int RowsPerPage { get; }

        public int SkippedRows
        {
            get
            {
                return (this.PageNumber - 1) * this.RowsPerPage;
            }
        }
    }
}
