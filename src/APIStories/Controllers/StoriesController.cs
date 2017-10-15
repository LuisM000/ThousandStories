using APIStories.Models;
using Model;
using Model.Services;
using System.Web.Http;

namespace APIStories.Controllers
{
    public class StoriesController : ApiController
    {
        readonly IStoryService storyService;
        public StoriesController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        // GET api/stories/5
        public IHttpActionResult Get(int id)
        {
            Story story = storyService.GetStory(id);
            if (story == null)
                return NotFound();
            return Ok(new StoryViewModel(story));
        }

    }
}
