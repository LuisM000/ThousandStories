using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Order;
using Repositories.StoryRepository;

namespace Model.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        public Story GetStory(int idStory)
        {
            return this.storyRepository.GetById(idStory);
        }

        public IPagedList<Story> GetLastestStories(string language, Pagination pagination)
        {
            if (pagination == null || string.IsNullOrEmpty(language))
                return null;

            return this.storyRepository.GetLastestStories(language, pagination);        
        }

        public IPagedList<Story> GetStoriesWithText(string text, string language, 
                                        Pagination pagination, IOrdering<Story> orderBy)
        {
            if (pagination == null || string.IsNullOrEmpty(language))
                return null;

            return this.storyRepository.GetWithText(text, language, pagination, orderBy ?? new StoryOrderByDate());
        }
    }
}
