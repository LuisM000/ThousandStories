using Repositories.StoryRepository;

namespace Model.Services
{
    public class StoryService : IStoryService
    {
        readonly IStoryRepository storyRepository;
        public StoryService(IStoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        public Story GetStory(int idStory)
        {
            return this.storyRepository.GetById(idStory);
        }
    }
}
