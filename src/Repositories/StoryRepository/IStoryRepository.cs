using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Order;
using Model;
using System.Collections.Generic;

namespace Repositories.StoryRepository
{
    public interface IStoryRepository : IRepository<Story>
    {
        IPagedList<Story> GetLastestStories(string language, Pagination pagination);
        IPagedList<Story> GetWithText(string text, string language, Pagination pagination, IOrdering<Story> orderBy);
        
    }
}
