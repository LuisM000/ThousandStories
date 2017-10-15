using APIStories.Controllers;
using APIStories.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Services;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;

namespace APIStories.Tests.Controllers
{
    [TestClass]
    public class StoriesControllerShould
    {
        [TestMethod]
        public void ReturnsAStoryById()
        {
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetStory(1)).Returns(new Story() { Title = new Title("title 1") });
            StoriesController storiesController = new StoriesController(storyService.Object);

            var result = storiesController.Get(1) as OkNegotiatedContentResult<StoryViewModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual("title 1", result.Content.Title);
        }

        [TestMethod]
        public void ReturnsNotFoundIfStoryNotExists()
        {
            Mock<IStoryService> storyService = new Mock<IStoryService>();
            storyService.Setup(s => s.GetStory(1)).Returns<Story>(null);
            StoriesController storiesController = new StoriesController(storyService.Object);

            var result = storiesController.Get(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }
    }
}
