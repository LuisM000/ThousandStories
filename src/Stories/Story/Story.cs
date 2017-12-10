using Infrastructure;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Story : Entity
    {
        public Story()
        {
        }

        public Story(string title, string text, Language language):this()
        {
            this.PublishDate = DateTime.Now;
            this.Rating=new Rating();

            this.Title=new Title(title);
            this.Content = new Content(text);
            this.Language = language;
        }

        public virtual Title Title { get; set; }
        public virtual Content Content { get; set; }
        public virtual VisualRepresentation VisualRepresentation { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual IList<DateTime> UpdateDates { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual Language Language { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual Rating Rating { get; set; }

    }
}
