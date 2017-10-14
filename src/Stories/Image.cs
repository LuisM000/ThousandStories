
using Infrastructure;
namespace Model
{
    public class Image : Entity
    {
        public int Index { get; set; }
        public byte[] Content { get; set; }
    }
}
