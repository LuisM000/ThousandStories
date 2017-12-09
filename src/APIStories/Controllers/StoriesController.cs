using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIStories.Models;
using Model;
using Model.Services;
using System.Web.Http;
using System.Web.Http.Description;
using APIStories.Attributes;
using APIStories.Models.Base;
using APIStories.Models.Story;
using Infrastructure;

namespace APIStories.Controllers
{
    [RoutePrefix("api/stories")]
    public class StoriesController : ApiController
    {
        private readonly IStoryService storyService;
        private readonly ILanguageService languageService;

        public StoriesController(IStoryService storyService, ILanguageService languageService)
        {
            this.storyService = storyService;
            this.languageService = languageService;
        }

        // GET api/stories/5
        public IHttpActionResult Get(int id)
        {
            Story story = storyService.GetStory(id);
            if (story == null)
                return NotFound();
            return Ok(new StoryResponse(story, this));
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

            return Ok(new PagedListResponse<StoryResponse>(pagedStories, pagedStories.Select(c => new StoryResponse(c,this))));
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
       
            return Ok(new PagedListResponse<StoryResponse>(pagedStories,pagedStories.Select(c=>new StoryResponse(c,this))));
        }

        // GET api/stories
        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        [ResponseType(typeof(StoryResponse))]
        public IHttpActionResult Post([FromBody]StoryRequest storyRequest)
        {
            Story story = storyRequest.CreateStory(this.languageService.GetLanguages());
            this.storyService.InsertAndSave(story);
            return Ok(new StoryResponse(story, this));//ToDo: redirect to new route
        }
    }
}
