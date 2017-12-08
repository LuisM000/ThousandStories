
using Infrastructure;
namespace Model
{
    public class Image : Entity
    {
        
        public int Index { get; set; }
        public virtual Data ImageData { get; set; }//ToDo: review lazy access
    }
}
