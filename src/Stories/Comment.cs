using Infrastructure;
using System;

namespace Model
{
    public class Comment : Entity
    {
        public virtual Content Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
