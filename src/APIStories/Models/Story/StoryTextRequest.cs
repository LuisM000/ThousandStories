using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIStories.Models.Story
{
    public class StoryTextRequest:StoryFilterRequest
    {
        [Required]
        public string Text { get; set; }

        public int? Category { get; set; }
    }
}