using Databases;
using Databases.Factories;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using Repositories.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Test
{

    [TestClass]
    public class StoryRepositoryShould
    {
        [TestMethod]
        public void ReturnStoriesWithTextInTitle()
        {
            Story storyTitle1 = new StoryBuilder().WithTitle("Title 1");
            Story storyTitle2 = new StoryBuilder().WithTitle("Title 2");
            FakeDbSet<Story> storyDbSet = new FakeDbSet<Story>()
            {
                storyTitle1,storyTitle2
            };
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(storyDbSet);
            StoryRepository.StoryRepository storyRepository = this.GivenAStoryRepositoryWithDatabase(database.Object);

            IEnumerable<Story> stories = storyRepository.GetWithText("Title 1", null, new Pagination(1, 10), new StoryOrderByDate()).ToList();

            Assert.AreEqual(1, stories.Count());
            Assert.AreEqual(storyTitle1, stories.FirstOrDefault());
        }

        [TestMethod]
        public void ReturnStoriesWithLanguage()
        {
            Story storyEs = new StoryBuilder().WithLanguage(Languages.es);
            Story storyEn = new StoryBuilder().WithLanguage(Languages.en);
            FakeDbSet<Story> storyDbSet = new FakeDbSet<Story>()
            {
                storyEs,storyEn
            };
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(storyDbSet);
            StoryRepository.StoryRepository storyRepository = this.GivenAStoryRepositoryWithDatabase(database.Object);

            IEnumerable<Story> stories = storyRepository.GetWithText(null, "en", new Pagination(1, 10), new StoryOrderByDate()).ToList();

            Assert.AreEqual(1, stories.Count());
            Assert.AreEqual(storyEn, stories.FirstOrDefault());
        }


        [TestMethod]
        public void ReturnLastestStoriesWithLanguage()
        {
            Story yesterdayStory = new StoryBuilder().WithPublishDate(DateTime.Now.AddDays(-1));
            Story todayStory = new StoryBuilder().WithPublishDate(DateTime.Now);
            Story dayBeforeYesterdayStory = new StoryBuilder().WithPublishDate(DateTime.Now.AddDays(-2));
            Story storyWithDifferentLanguage = new StoryBuilder().WithLanguage(Languages.en).WithPublishDate(DateTime.Now);

            FakeDbSet<Story> storyDbSet = new FakeDbSet<Story>()
            {
                dayBeforeYesterdayStory,todayStory,yesterdayStory
            };
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(storyDbSet);
            StoryRepository.StoryRepository storyRepository = this.GivenAStoryRepositoryWithDatabase(database.Object);

            IList<Story> stories = storyRepository.GetLastestStories(null, new Pagination(1, 10)).ToList();

            Assert.AreEqual(3, stories.Count());
            Assert.AreEqual(todayStory, stories[0]);
            Assert.AreEqual(yesterdayStory, stories[1]);
            Assert.AreEqual(dayBeforeYesterdayStory, stories[2]);
        }


       

        private StoryRepository.StoryRepository GivenAStoryRepositoryWithDatabase(DataBase database)
        {
            return new StoryRepository.StoryRepository(FakeDatabase.GivenAFactoryWithDatabase(database).Object);
        }


    }
}
