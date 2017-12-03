using Model;
using System;

namespace Model
{
    public enum Languages { en, es };

    public class StoryBuilder
    {
        private readonly Story story;

        public StoryBuilder()
        {
            story = new Story()
            {
                Language = new Model.Language(),
                Content = new Content(),
                Rating = new Rating()
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

        public StoryBuilder WithRating(int rating)
        {
            story.Rating.Positives = rating;
            story.Rating.Negatives = 0;
            return this;
        }

        public static implicit operator Story(StoryBuilder builder)
        {
            return builder.story;
        }
    }
}
