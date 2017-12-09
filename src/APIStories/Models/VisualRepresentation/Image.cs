﻿
namespace APIStories.Models.VisualRepresentation
{
    public class Image
    {
        public int Index { get; set; }
        public byte[] ImageData { get; set; }

        public Model.Image CreateImage()
        {
            return new Model.Image(this.Index, new Model.Data(this.ImageData));
        }
    }
}