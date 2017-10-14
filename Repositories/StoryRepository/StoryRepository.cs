
using Databases.Factories;
using Infrastructure;
using Infrastructure.Specification;
using Model.Story;
using System.Collections.Generic;

namespace Repositories.StoryRepository
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(IFactoryDB factoryDB) : base(factoryDB) { }

        public IEnumerable<Story> GetRelevantStories(Pagination pagination, string language)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Story> GetWithText(string text, string language, Pagination pagination, IOrdering<Story> orderBy)
        {
            var query = new Query<Story>(new StoryWithTextSpec(text).And(new StoryWithLanguageSpec(language)),
                pagination, orderBy);
            return base.GetAll(query);
        }
    }
}
