using System.Linq;

namespace Infrastructure.Order
{
    public static class IOrderExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, IOrdering<T> orderBy)
        {
            return orderBy.OrderingBy(query);
        }
    }
}
