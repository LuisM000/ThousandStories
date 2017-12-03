using Infrastructure.Order;
using System.Linq;

namespace Model
{
    public class StoryOrderByDate : IOrdering<Story>
    {
        public IOrderedQueryable<Story> OrderingBy(IQueryable<Story> query)
        {
            return query.OrderByDescending(s => s.PublishDate);
        }
    }
}
