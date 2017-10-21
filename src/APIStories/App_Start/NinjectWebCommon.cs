[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(APIStories.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(APIStories.App_Start.NinjectWebCommon), "Stop")]

namespace APIStories.App_Start
{
    using Databases;
    using Databases.Factories;
    using Databases.Initializers;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using SharedIoC;
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var composer = new StandardKernel(new Composer());
            try
            {
                composer.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                composer.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(composer);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(composer);
                return composer;
            }
            catch(Exception)
            {
                composer.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFactoryDB>().To<FactorySQL>().InSingletonScope();
            kernel.Bind<IDatabaseInitializer<DataBaseSQL>>().To<UpdateInitializer>();
        }
    }
}
