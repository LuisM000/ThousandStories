using System;
using System.Linq;

namespace Infrastructure
{
    public interface IOrdering<T>
    {
        Func<IQueryable<T>, IOrderedQueryable<T>> Sort { get; }


    }
}
