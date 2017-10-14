using Databases;
using Databases.Factories;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Story;
using Moq;
using Repositories.Test.Fakes;
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
            Story storyTitle1 = this.GivenAStoryWithTitle("Title 1");
            Story storyTitle2 = this.GivenAStoryWithTitle("Title 2");
            FakeDbSet<Story> storyDbSet = new FakeDbSet<Story>()
            {
                storyTitle1,storyTitle2
            };
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(storyDbSet);
            StoryRepository.StoryRepository storyRepository = this.GivenAStoryRepositoryWithDatabase(database.Object);

            IEnumerable<Story> stories = storyRepository.GetWithText("Title 1", null, new Pagination(0, 10), new StoryOrderByDate()).ToList();

            Assert.AreEqual(1, stories.Count());
            Assert.AreEqual(storyTitle1, stories.FirstOrDefault());
        }

        [TestMethod]
        public void ReturnStoriesWithLanguage()
        {
            Story storyEs = this.GivenAStoryWithLanguage("es");
            Story storyEn = this.GivenAStoryWithLanguage("en");
            FakeDbSet<Story> storyDbSet = new FakeDbSet<Story>()
            {
                storyEs,storyEn
            };
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(storyDbSet);
            StoryRepository.StoryRepository storyRepository = this.GivenAStoryRepositoryWithDatabase(database.Object);

            IEnumerable<Story> stories = storyRepository.GetWithText(null, "en", new Pagination(0, 10), new StoryOrderByDate()).ToList();

            Assert.AreEqual(1, stories.Count());
            Assert.AreEqual(storyEn, stories.FirstOrDefault());
        }




        private Story GivenAStoryWithTitle(string title)
        {
            return new Story() { Title = title, Language = new Language() { } };
        }
        private Story GivenAStoryWithLanguage(string language)
        {
            return new Story() { Language = new Language() { LanguageIdentifier = language } };
        }
        private StoryRepository.StoryRepository GivenAStoryRepositoryWithDatabase(DataBase database)
        {
            return new StoryRepository.StoryRepository(FakeDatabase.GivenAFactoryWithDatabase(database).Object);
        }
       

    }
}
