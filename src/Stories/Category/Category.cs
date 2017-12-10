
using Infrastructure;
using System.Collections.Generic;
namespace Model
{
    public class Category : Entity
    {
        public virtual MultilingualString Name { get; set; }
        public virtual IList<Category> Subcategories { get; set; }
        public bool IsMainCategory { get; set; }
    }
}
