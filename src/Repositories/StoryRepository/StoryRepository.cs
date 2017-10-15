using Databases.Factories;
using Infrastructure;
using Infrastructure.Order;
using Infrastructure.Specification;
using Model;
using System.Collections.Generic;

namespace Repositories.StoryRepository
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(IFactoryDB factoryDB) : base(factoryDB) { }

        public IEnumerable<Story> GetLastestStories(string language, Pagination pagination)
        {
            var query = new Query<Story>(new StoryWithLanguageSpec(language), pagination, new StoryOrderByDate());
            return base.GetAll(query);
        }

        public IEnumerable<Story> GetWithText(string text, string language, Pagination pagination, IOrdering<Story> orderBy)
        {
            var query = new Query<Story>(new StoryWithTextSpec(text).And(new StoryWithLanguageSpec(language)),
                pagination, orderBy);
            return base.GetAll(query);
        }
    }
}
