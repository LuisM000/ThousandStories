using Model.Services;
using Ninject.Modules;
using Repositories.StoryRepository;

namespace SharedIoC
{
    public class Composer : NinjectModule
    {
        public override void Load()
        {
            //Model.Services
            this.Bind<IStoryService>().To<StoryService>();

            //Repositories
            this.Bind<IStoryRepository>().To<StoryRepository>();

        }
    }
}
