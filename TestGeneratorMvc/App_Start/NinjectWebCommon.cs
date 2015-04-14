[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TestGeneratorMvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TestGeneratorMvc.App_Start.NinjectWebCommon), "Stop")]

namespace TestGeneratorMvc.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Services;
    using DataLayer.Implementations.ApplicationDbContext;
    using DataLayer.Implementations.Implementations;
    using DataLayer.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<TestGeneratorDbContext>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IAnswerRepository>().To<AnswerRepository>().InRequestScope();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>().InRequestScope();
            kernel.Bind<ITagRepository>().To<TagRepository>().InRequestScope();
            kernel.Bind<ITestExportRepository>().To<TestExportRepository>().InRequestScope();
            kernel.Bind<ITestRepository>().To<TestRepository>().InRequestScope();
            kernel.Bind<IUserAnswerRepository>().To<UserAnswerRepository>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();

            kernel.Bind<IAnswerService>().To<AnswerService>().InRequestScope();
            kernel.Bind<IQuestionCreateService>().To<QuestionCreateService>().InRequestScope();
            kernel.Bind<IQuestionImportService>().To<QuestionImportService>().InRequestScope();
            kernel.Bind<IQuestionViewService>().To<QuestionViewService>().InRequestScope();
            kernel.Bind<ITagService>().To<TagService>().InRequestScope();
            kernel.Bind<ITestCreateService>().To<TestCreateService>().InRequestScope();
            kernel.Bind<ITestExportCreateService>().To<TestExportCreateService>().InRequestScope();
            kernel.Bind<ITestExportEditService>().To<TestExportEditService>().InRequestScope();
            kernel.Bind<ITestExportViewService>().To<TestExportViewService>().InRequestScope();
            kernel.Bind<ITestViewService>().To<TestViewService>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }        
    }
}
