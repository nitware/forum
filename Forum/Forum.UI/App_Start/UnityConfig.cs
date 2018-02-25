using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using System.Data.Entity;
using Forum.Domain.Entities.Core;
using Forum.Service.Interfaces;
using Forum.Service;
using Forum.Domain.Entities;
using Forum.Data;
using System.Web.Security;

namespace Forum.UI
{
    public static class UnityConfig
    {
        public static UnityContainer Container;

        public static void RegisterComponents()
        {
            Container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());


            Container.RegisterType<DbContext, EntityContext>();
            Container.RegisterType<IRepository<Comment>, Repository<Comment>>();
            Container.RegisterType<IRepository<Category>, Repository<Category>>();
            Container.RegisterType<IRepository<User>, Repository<User>>();
            Container.RegisterType<IRepository<Role>, Repository<Role>>();
            Container.RegisterType<IRepository<Post>, Repository<Post>>();
            Container.RegisterType<IPostService, PostService>();
            Container.RegisterType<BaseService<Category>, CategoryService>();
            Container.RegisterType<BaseService<Comment>, CommentService>();
            Container.RegisterType<IMembershipService, MembershipService>();
            Container.RegisterType<IRepository<View>, Repository<View>>();
            Container.RegisterType<IDataSeedService, DataSeedService> ();
            Container.RegisterType<ICryptoService, CryptoService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }



    }
}