using System.Collections.Generic;
using Infrastructure;
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

        public IEnumerable<Story> GetLastestStories(string language, Pagination pagination)
        {
            if (pagination == null || string.IsNullOrEmpty(language))
                return null;

            return this.storyRepository.GetLastestStories(language, pagination);        
        }
    }
}
