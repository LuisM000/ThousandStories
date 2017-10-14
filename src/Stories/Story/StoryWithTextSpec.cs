using Infrastructure.Specification;
using System;
using System.Linq.Expressions;

namespace Model.Story
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
            return x => (x.Content != null && x.Content.Text == text) ||
                        (x.Title !=null && x.Title.Value == text);
        }

    }
}
