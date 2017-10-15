using Model;

namespace APIStories.Models
{
    public class StoryViewModel
    {
        public string Title { get; private set; }
        public string Content { get; private set; }


        public StoryViewModel(Story story)
        {
            if (story.Title != null)
                this.Title = story.Title.Value;
            if (story.Content != null)
                this.Content = story.Content.Text;
        }
    }
}