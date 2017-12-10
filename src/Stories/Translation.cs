using Infrastructure;

namespace Model
{
    public class Translation : Entity
    {
        protected Translation() { }

        public Translation(string text, Language language)
        {
            this.Text = text;
            this.Language = language;
        }

        public string Text { get; set; }
        public virtual Language Language { get; set; }

        public bool IsThisTranslation(string language)
        {
            return (this.Language != null && this.Language.IsThisLanguage(language));
        }

    }
}
