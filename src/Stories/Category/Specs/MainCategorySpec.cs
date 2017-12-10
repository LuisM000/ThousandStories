using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Specification;

namespace Model
{
    public class MainCategorySpec : ISpecification<Category>
    {
       
        public Expression<Func<Category, bool>> IsSatisifiedBy()
        {
            return x => (x.IsMainCategory);
        }

    }
}



