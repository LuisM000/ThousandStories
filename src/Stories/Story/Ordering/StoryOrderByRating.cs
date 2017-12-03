using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Order;

namespace Model
{
    public class StoryOrderByRating : IOrdering<Story>
    {
        public IOrderedQueryable<Story> OrderingBy(IQueryable<Story> query)
        {
            return query.OrderByDescending(s => s.Rating.Popularity);
        }
    }
}
