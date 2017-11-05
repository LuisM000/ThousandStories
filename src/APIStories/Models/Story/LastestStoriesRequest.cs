using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Infrastructure;

namespace APIStories.Models.Story
{
    public class LastestStoriesRequest
    {
        [Required]
        public string Language { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public int RowsPerPage { get; set; }

        public Pagination GetPagination()
        {
            return new Pagination(this.Page,this.RowsPerPage);
        }
    }
}