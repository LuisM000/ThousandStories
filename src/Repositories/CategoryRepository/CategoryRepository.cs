using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databases.Factories;
using Infrastructure;
using Model;

namespace Repositories.CategoryRepository
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(IFactoryDB factoryDB) : base(factoryDB)
        {
        }

        public IEnumerable<Category> GetMainCategories()
        {
            var query = new Query<Category>(new MainCategorySpec(), null, null);
            return GetAll(query);
        }
    }
}
