using Infrastructure;

namespace Model
{
    public class Translation : Entity
    {
        public string Text { get; set; }
        public virtual Language Language { get; set; }

        public bool IsThisTranslation(string language)
        {
            return (this.Language != null && this.Language.IsThisLanguage(language));
        }

    }
}
