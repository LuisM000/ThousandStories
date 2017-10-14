using Infrastructure;
using Infrastructure.Order;
using System;
using System.Linq;

namespace Model.Story
{
    public class StoryOrderByDate : IOrdering<Story>
    {      
        public IOrderedQueryable<Story> OrderingBy(IQueryable<Story> query)
        {
            return query.OrderBy(s => s.PublishDate);
        }
    }
}
