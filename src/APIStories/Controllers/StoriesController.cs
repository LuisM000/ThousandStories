using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIStories.Models;
using Model;
using Model.Services;
using System.Web.Http;
using APIStories.Attributes;
using APIStories.Models.Story;

namespace APIStories.Controllers
{
    [RoutePrefix("api/stories")]
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
            return Ok(new StoryRespose(story));
        }

        // GET api/stories/home
        [CheckModelForNull]
        [ValidateModelState]
        [Route("home")]
        public IHttpActionResult GetHome([FromUri][Required]LastestStoriesRequest lastestStoriesRequest)
        {
            IEnumerable<Story> stories = storyService.GetLastestStories(lastestStoriesRequest.Language,
                                            lastestStoriesRequest.GetPagination());
            if (stories == null)
                return NotFound();

            return Ok(stories.Select(s=>new StoryRespose(s)));
        }

    }
}
