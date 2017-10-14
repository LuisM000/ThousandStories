using Model;

namespace UseCases.Model
{
    public class LanguageMapped : MappedEntity<Language>
    {
        public string LanguageIdentifier { get; set; }
    }
}