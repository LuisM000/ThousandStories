using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Infrastructure;

namespace APIStories.Models.Story
{
    public class StoryFilterRequest
    {
        public StoryFilterRequest()
        {
            this.RowsPerPage = 10;
            this.Page = 1;
        }

        [Required]
        public string Language { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Page { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int RowsPerPage { get; set; }

        public Pagination GetPagination()
        {
            return new Pagination(this.Page,this.RowsPerPage);
        }
    }
}