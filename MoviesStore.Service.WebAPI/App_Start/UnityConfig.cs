using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using Microsoft.Practices.Unity.Configuration;
using MoviesStore.Service.BL;
using MoviesStore.Service.DAL.ADORepository;
using MoviesStore.Service.DAL.IRepository;

namespace MoviesStore.Service.WebAPI
{
    public static class UnityConfig
    {

        //public static Lazy<UnityContainer> container = new Lazy<UnityContainer>();
        public static void RegisterComponents()
        {

            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMoviesManager, MoviesManager>();
            container.RegisterType<IMasterDataManager, MasterDataManager>();
            container.RegisterType<IMasterDataRepository, MasterDataRepository>();
            container.RegisterType<IMoviesRepository, MoviesRepository>();
            container.RegisterType<IActorManager, ActorManager>();
            container.RegisterType<IActorRepository, ActorRepository>();
            container.RegisterType<IProducerManager, ProducerManager>();
            container.RegisterType<IProducerRepository, ProducerRepository>();
            container.RegisterType<IDapperRepository, DapperRepository>();
            
            //container.Value.LoadConfiguration();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}