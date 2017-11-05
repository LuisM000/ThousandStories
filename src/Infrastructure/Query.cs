
using Infrastructure.Order;
using Infrastructure.Specification;
using System.Linq;
namespace Infrastructure
{
    public class Query<TEntity>
    {
        public Query(ISpecification<TEntity> specification, Pagination pagination, IOrdering<TEntity> orderBy)
        {
            this.Pagination = pagination;
            this.OrderBy = orderBy;
            this.Specification = specification;
        }

        public Pagination Pagination { get; private set; }
        public IOrdering<TEntity> OrderBy { get; private set; }
        public ISpecification<TEntity> Specification { get; private set; }


        public IQueryable<TEntity> Prepare(IQueryable<TEntity> queryable)
        {
            if (queryable == null)
                return null;
            if (Specification != null)
                queryable = queryable.Where(Specification.IsSatisifiedBy());
            if (OrderBy != null)
                queryable = queryable.OrderBy(OrderBy);
            if (Pagination != null)
                queryable = queryable.Skip(Pagination.SkippedRows).Take(Pagination.RowsPerPage);
            

            return queryable;
        }
    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> Prepare<T>(this IQueryable<T> queryable, Query<T> query)
        {
            return query.Prepare(queryable);
        }


    }
}
