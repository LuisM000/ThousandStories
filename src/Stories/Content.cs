
using Infrastructure;
namespace Model
{
    public class Content : Entity
    {
        protected Content() { }

        public Content(string text)
        {
            this.Text = text;
        }
        public string Text { get; set; }
    }
}
