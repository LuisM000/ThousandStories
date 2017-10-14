using Infrastructure.Specification;
using System;
using System.Linq.Expressions;

namespace Model.Story
{
    public class StoryWithLanguageSpec : ISpecification<Story>
    {
        private readonly string language;

        public StoryWithLanguageSpec(string language)
        {
            this.language = language;
        }

        public Expression<Func<Story, bool>> IsSatisifiedBy()
        {
            return x => (x.Language != null && x.Language.IsThisLanguage(language));
        }

    }
}

