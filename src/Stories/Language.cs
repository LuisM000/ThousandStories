
using Infrastructure;
namespace Model
{
    public class Language : Entity
    {
        public string LanguageIdentifier { get; set; }

        public bool IsThisLanguage(string language)
        {
            return this.LanguageIdentifier == language;
        }
    }
}
