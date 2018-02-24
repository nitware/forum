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
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());


            container.RegisterType<DbContext, EntityContext>();
            container.RegisterType<IRepository<Comment>, Repository<Comment>>();
            container.RegisterType<IRepository<Category>, Repository<Category>>();
            container.RegisterType<IRepository<Person>, Repository<Person>>();
            container.RegisterType<IRepository<Role>, Repository<Role>>();
            container.RegisterType<IRepository<Post>, Repository<Post>>();
            container.RegisterType<IPostService, PostService>();
            container.RegisterType<BaseService<Category>, CategoryService>();
            container.RegisterType<BaseService<Comment>, CommentService>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<IRepository<View>, Repository<View>>();
            //container.RegisterType<BaseService<View>, ViewService> ();
            container.RegisterType<ICryptoService, CryptoService>();
                                    
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }



    }
}