using System.Linq;

namespace Infrastructure.Order
{
    public interface IOrdering<T>
    {
        IOrderedQueryable<T> OrderingBy(IQueryable<T> query);
    }
}
