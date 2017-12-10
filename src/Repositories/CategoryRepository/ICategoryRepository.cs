using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Model;

namespace Repositories.CategoryRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        IEnumerable<Category> GetMainCategories();

    }
}
