using System.Collections.Generic;
using System.Linq;
using APIStories.Controllers;
using APIStories.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Services;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using APIStories.Models.Base;
using APIStories.Models.Story;
using Infrastructure;

namespace APIStories.Tests.Controllers
{
    [TestClass]
    public class StoriesControllerShould
    {
        [TestMethod]
        public void ReturnsAStoryById()
        {
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetStory(1)).Returns(new StoryBuilder().WithTitle("title 1"));
            StoriesController storiesController = new StoriesController(storyService.Object,null);

            var result = storiesController.Get(1) as OkNegotiatedContentResult<StoryResponse>;

            Assert.IsNotNull(result);
            Assert.AreEqual("title 1", result.Content.Title);
        }

        [TestMethod]
        public void ReturnsNotFoundIfStoryNotExists()
        {
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetStory(1)).Returns<Story>(null);
            StoriesController storiesController = new StoriesController(storyService.Object, null);

            var result = storiesController.Get(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void ReturnsLastestStories()
        {
            var lastestStories = new List<Story>()
            {
                new StoryBuilder().WithTitle("title 1"),
                new StoryBuilder().WithTitle("title 2"),
            };
           
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetLastestStories(It.IsAny<string>(),
                        It.IsAny<Pagination>())).Returns(new StaticPagedList<Story>(lastestStories));
            StoriesController storiesController = new StoriesController(storyService.Object, null);

            var result = storiesController.GetHome(new StoryFilterRequest()) as OkNegotiatedContentResult<PagedListResponse<StoryResponse>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2,result.Content.Items.Count());
            Assert.AreEqual("title 2", result.Content.Items.ToList()[1].Title);
        }


        [TestMethod]
        public void ReturnsNotFoundIfThereAreNotLastestStoriesWithSpecifications()
        {
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetLastestStories(It.IsAny<string>(),
                It.IsAny<Pagination>())).Returns<IEnumerable<Story>>(null);
            StoriesController storiesController = new StoriesController(storyService.Object, null);

            var result = storiesController.GetHome(new StoryFilterRequest(){});

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }
    }
    }
