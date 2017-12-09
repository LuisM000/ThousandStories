using Model.Services;
using Ninject.Modules;
using Repositories.ImageRepository;
using Repositories.LanguageRepository;
using Repositories.StoryRepository;

namespace SharedIoC
{
    public class Composer : NinjectModule
    {
        public override void Load()
        {
            //Model.Services
            this.Bind<IStoryService>().To<StoryService>();
            this.Bind<IImageService>().To<ImageService>();
            this.Bind<ILanguageService>().To<LanguageService>();

            //Repositories
            this.Bind<IStoryRepository>().To<StoryRepository>();
            this.Bind<IImageRepository>().To<ImageRepository>();
            this.Bind<ILanguageRepository>().To<LanguageRepository>();


        }
    }
}
