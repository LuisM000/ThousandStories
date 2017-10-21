using Model;
using System;

namespace Repositories.Test.Builders
{
    public enum Languages { en, es };

    public class StoryBuilder
    {
        private Story story;

        public StoryBuilder()
        {
            story = new Story()
            {
                Language = new Model.Language(),
                Content = new Content()
            };
        }

        public StoryBuilder WithLanguage(Languages language)
        {
            story.Language.LanguageIdentifier = language.ToString();
            return this;
        }

        public StoryBuilder WithTitle(string title)
        {
            story.Title = new Title(title);
            return this;
        }

        public StoryBuilder WithContent(string text)
        {
            story.Content.Text = text;
            return this;
        }

        public StoryBuilder WithPublishDate(DateTime dateTime)
        {
            story.PublishDate = dateTime;
            return this;
        }

        public static implicit operator Story(StoryBuilder builder)
        {
            return builder.story;
        }
    }
}
