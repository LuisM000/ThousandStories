using Model;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Model
{
    public class CategoryMapped : MappedEntity<Category>
    {
        public string Name { get; set; }
        public IEnumerable<CategoryMapped> Subcategories { get; set; }

        public static CategoryMapped Create(Category category, string language)
        {
            if (category == null)
                return null;
            return new CategoryMapped()
            {
                Name = category.Name.GetText(language),
                Subcategories = (category.Subcategories != null) ?
                                category.Subcategories.Select(c => CategoryMapped.Create(c, language)) :
                                null

            };
        }

    }
}
