using Infrastructure;
namespace Model
{
    public class Image : Entity
    {
        protected Image() { }

        public Image(int index, Data imageData)
        {
            this.Index = index;
            this.ImageData = imageData;
        }
        public int Index { get; set; }
        public virtual Data ImageData { get; set; }
    }
}
