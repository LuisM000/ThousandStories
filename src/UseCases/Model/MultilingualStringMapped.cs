using Model;
using System.Collections.Generic;

namespace UseCases.Model
{
    public class MultilingualStringMapped : MappedEntity<MultilingualString>
    {
        public string Text { get; set; }

        public IEnumerable<TranslationMapped> Translations { get; set; }

    }
}

