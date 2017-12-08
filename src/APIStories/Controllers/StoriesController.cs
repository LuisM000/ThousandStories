using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIStories.Models;
using Model;
using Model.Services;
using System.Web.Http;
using APIStories.Attributes;
using APIStories.Models.Base;
using APIStories.Models.Story;
using Infrastructure;

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
            return Ok(new StoryRespose(story, this));
        }

        // GET api/stories?Language='es'&Page=1&RowsPerPage=3&Text='texto'
        [CheckModelForNull]
        [ValidateModelState]
        public IHttpActionResult Get([FromUri]StoryTextRequest storyTextRequest)
        {
            IPagedList<Story> pagedStories = storyService.GetStoriesWithText(storyTextRequest.Text,
                storyTextRequest.Language, storyTextRequest.GetPagination(), storyTextRequest.GetOrdering());
            if (pagedStories == null)
                return NotFound();

            return Ok(new PagedListResponse<StoryRespose>(pagedStories, pagedStories.Select(c => new StoryRespose(c,this))));
        }

        // GET api/stories/home?Language=es&Page=1&RowsPerPage=3
        [CheckModelForNull]
        [ValidateModelState]
        [Route("home")]
        public IHttpActionResult GetHome([FromUri]StoryFilterRequest storyFilterRequest)
        {
            IPagedList<Story> pagedStories = storyService.GetLastestStories(storyFilterRequest.Language,
                                            storyFilterRequest.GetPagination());
            if (pagedStories == null)
                return NotFound();
       
            return Ok(new PagedListResponse<StoryRespose>(pagedStories,pagedStories.Select(c=>new StoryRespose(c,this))));
        }

    }
}
