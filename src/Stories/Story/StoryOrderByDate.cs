using Infrastructure;
using System;
using System.Linq;

namespace Model.Story
{
    public class StoryOrderByDate : IOrdering<Story>
    {
        public Func<IQueryable<Story>, IOrderedQueryable<Story>> Sort
        {
            get { return stories => stories.OrderBy(s => s.PublishDate); }
        }
    }
}
