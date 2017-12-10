using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.CategoryRepository;
using Repositories.LanguageRepository;

namespace Model.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IList<Category> GetCategories()
        {
            return categoryRepository.GetMainCategories().ToList();
        }
    }
}
