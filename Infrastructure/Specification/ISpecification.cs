using System;
using System.Linq.Expressions;

namespace Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisifiedBy();

    }
}
