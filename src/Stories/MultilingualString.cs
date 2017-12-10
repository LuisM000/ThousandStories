using Infrastructure;
using System.Collections.Generic;
using System.Linq;


namespace Model
{
    public class MultilingualString : Entity
    {
        public string DefaultText { get; set; }

        public virtual IList<Translation> Translations { get; set; }


        public string GetText(string language)
        {
            if (this.Translations != null && !string.IsNullOrEmpty(language))
            {
                Translation translation = this.Translations.FirstOrDefault(t => t.IsThisTranslation(language));
                if (translation != null)
                    return translation.Text;
            }

            return this.DefaultText;
        }


    }
}
