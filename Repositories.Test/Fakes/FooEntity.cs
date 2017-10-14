
using Infrastructure;
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
        public Func<IQueryable<FooEntity>, IOrderedQueryable<FooEntity>> Sort
        {
            get { return stories => stories.OrderBy(s => s.Id); }
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
