using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace APIStories.Models.Category
{
    public class TranslationResponse
    {
        public string Text { get; }
        public string Language { get;  }

        public TranslationResponse(Translation translation)
        {
            if(translation==null)
                return;

            this.Text = translation.Text;
            this.Language = translation.Language?.LanguageIdentifier;
        }
    }
}