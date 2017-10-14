
using Infrastructure;
using Infrastructure.Order;
using Infrastructure.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace Repositories.Test.Fakes
{
    public class FooEntity : Entity
    {
        public string Bar { get; set; }

    }

    public class FooOrderById : IOrdering<FooEntity>
    {
        public IOrderedQueryable<FooEntity> OrderingBy(IQueryable<FooEntity> query)
        {
            return query.OrderBy(s => s.Id);
        }
    }

    public class FooOrderByDescendingId : IOrdering<FooEntity>
    {
        public IOrderedQueryable<FooEntity> OrderingBy(IQueryable<FooEntity> query)
        {
            return query.OrderByDescending(s => s.Id);
        }
    }

    public class FooWithBarSpec : ISpecification<FooEntity>
    {
        private readonly string barText;

        public FooWithBarSpec(string barText)
        {
            this.barText = barText;
        }

        public Expression<Func<FooEntity, bool>> IsSatisifiedBy()
        {
            return x => x.Bar == barText;
        }

    }
}
