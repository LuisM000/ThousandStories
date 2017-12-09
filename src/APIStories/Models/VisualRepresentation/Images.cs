using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIStories.Models.VisualRepresentation
{
    public class Images
    {
        public IList<Image> ImageRepresentations { get; set; }

        public Model.VisualRepresentation CreateVisualRepresentation()
        {
            var visualRepresentation = new Model.VisualRepresentation();
            visualRepresentation.Images = ImageRepresentations?.Select(ir => ir.CreateImage()).ToList();

            return visualRepresentation;
        }
    }
}