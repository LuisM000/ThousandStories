using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIStories.Models.Category
{
    public class CategoryResponse
    {
        public string Description { get; }
        public IList<TranslationResponse> Translations { get; }

        public IList<CategoryResponse> Subcategories { get; }
        
        public CategoryResponse(Model.Category category)
        {
            if(category==null)
                return;

            this.Description = category.Name?.DefaultText;
            this.Translations = category.Name?.Translations?.Select(t => new TranslationResponse(t)).ToList();

            this.Subcategories = category.Subcategories?.Select(sc => new CategoryResponse(sc)).ToList();
        }
    }
}