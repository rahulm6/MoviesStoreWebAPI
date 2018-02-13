
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity.Configuration;
using MoviesStore.Web.Controllers;
using MoviesStore.Web.Models;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace MoviesStore.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITopicManager, TopicManager>();
            //container.RegisterType<ITopicManager, TopicManager>();
            //container.RegisterType<IQuoteManager, QuoteManager>();
            //container.RegisterType<ISubjectManager, SubjectManager>();
            //container.RegisterType<IExamModuleManager, ExamModuleManager>();
            //container.RegisterType<IMasterDataManager, MasterDataManager>();
            //container.RegisterType<IQuestionManager, QuestionManager>();
            //container.RegisterType<ITestManager, TestManager>();
            //container.RegisterType<IAnalyticalManager, AnalyticalManager>();
            //container.RegisterType<ITestRepository, TestRepository>();
            //container.RegisterType<IQuoteRepository, QuoteRepository>();
            //container.RegisterType<ISubjectRepository, SubjectRepository>();
            //container.RegisterType<IExamModuleRepository, ExamModuleRepository>();
            //container.RegisterType<ITopicRepository, TopicRepository>();
            //container.RegisterType<IQuestionRepository, QuestionRepository>();
            //container.RegisterType<IUnitOfWork, EFUnitOfWork>();
            container.RegisterType<DbContext, ApplicationDbContext>(
    new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(
                new InjectionConstructor());
            //container.LoadConfiguration();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}