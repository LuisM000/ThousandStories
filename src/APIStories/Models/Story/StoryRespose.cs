namespace APIStories.Models.Story
{
    public class StoryRespose
    {
        public string Title { get; }
        public string Content { get; }
        public int? Popularity { get; }

        public StoryRespose(Model.Story story)
        {
            if(story==null)
                return;

            this.Title = story.Title?.Value;
            this.Content = story.Content?.Text;
            this.Popularity = story.Rating?.Popularity;

        }
    }
}