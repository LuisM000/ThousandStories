using Infrastructure.Specification;
using System;
using System.Linq.Expressions;

namespace Model
{
    public class StoryWithTextSpec : ISpecification<Story>
    {
        private readonly string text;

        public StoryWithTextSpec(string text)
        {
            this.text = text;
        }

        public Expression<Func<Story, bool>> IsSatisifiedBy()
        {
            return x => (x.Content != null && x.Content.Text!=null && x.Content.Text.Contains(text) ||
                        (x.Title !=null && x.Title.Value!=null && x.Title.Value.Contains(text)));
        }

    }
}
