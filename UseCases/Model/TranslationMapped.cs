
using Model;
namespace UseCases.Model
{
    public class TranslationMapped : MappedEntity<Translation>
    {
        public string Text { get; set; }
        public LanguageMapped Language { get; set; }
    }
}

