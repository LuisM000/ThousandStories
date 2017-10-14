using Domain.Interfaces;
using Infrastructure;
using Model.Story;
using System.Collections.Generic;

namespace Repositories.StoryRepository
{
    public interface IStoryRepository : IRepository<Story>
    {
        IEnumerable<Story> GetRelevantStories(Pagination pagination, string language);
        IEnumerable<Story> GetWithText(string text, string language, Pagination pagination, IOrdering<Story> orderBy);


    }
}
