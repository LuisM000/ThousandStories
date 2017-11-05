namespace APIStories.Models.Story
{
    public class StoryRespose
    {
        public string Title { get; }
        public string Content { get; }


        public StoryRespose(Model.Story story)
        {
            if (story.Title != null)
                this.Title = story.Title.Value;
            if (story.Content != null)
                this.Content = story.Content.Text;
        }
    }
}