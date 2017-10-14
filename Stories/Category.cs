
using Infrastructure;
using System.Collections.Generic;
namespace Model
{
    public class Category : Entity
    {
        public virtual MultilingualString Name { get; set; }
        public virtual IEnumerable<Category> Subcategories { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
