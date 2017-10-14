using Infrastructure;
using System;
using System.Collections.Generic;

namespace Model.Story
{
    public class Story : Entity
    {
        public string Title { get; set; }
        public virtual Content Content { get; set; }//ToDo: review if virtual is necessary (for lazy load??)
        public virtual IEnumerable<Image> Images { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual IEnumerable<DateTime> UpdateDates { get; set; }
        public virtual Language Language { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual Rating Rating { get; set; }

    }
}
