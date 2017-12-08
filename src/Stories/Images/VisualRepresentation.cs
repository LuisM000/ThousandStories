using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Model
{
    public class VisualRepresentation:Entity
    {
        public virtual IList<Image> Images { get; set; }

        public Image GetMainImage()
        {
            return Images?.OrderBy(i => i.Index).FirstOrDefault();
        }
    }
}
