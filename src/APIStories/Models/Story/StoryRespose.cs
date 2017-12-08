using System.Linq;
using System.Web.Http;
using APIStories.Controllers;
using APIStories.Helpers;
using Microsoft.Ajax.Utilities;

namespace APIStories.Models.Story
{
    public class StoryRespose
    {
        public string Title { get; }
        public string Content { get; }
        public int? Popularity { get; }
        public string MainImage { get; }
        

        public StoryRespose(Model.Story story, ApiController apiController)
        {
            if(story==null)
                return;

            this.Title = story.Title?.Value;
            this.Content = story.Content?.Text;
            this.Popularity = story.Rating?.Popularity;
            var mainImage = story.VisualRepresentation?.GetMainImage();
            if (mainImage != null)
            {
                this.MainImage = apiController.GetImageRoute(mainImage.Id);
            }
        }
 
    }
}