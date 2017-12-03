using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Infrastructure.Order;

namespace APIStories.Models.Story
{
    public class StoryTextRequest:StoryFilterRequest
    {
        [Required]
        public string Text { get; set; }

        public int? Category { get; set; }

        public OrderBy OrderBy { get; set; }

        
        public IOrdering<Model.Story> GetOrdering()
        {
            return new OrderByRequest(this.OrderBy).GetOrdering();
        }
    }
}