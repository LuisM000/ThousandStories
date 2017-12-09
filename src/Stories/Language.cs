
using Infrastructure;
namespace Model
{
    public class Language : Entity
    {
        private Language() { }
        public Language(string languageIdentifier)
        {
            this.LanguageIdentifier = languageIdentifier;
        }

        public string LanguageIdentifier { get; set; }

        public bool IsThisLanguage(string language)
        {
            return this.LanguageIdentifier == language;
        }
    }
}
