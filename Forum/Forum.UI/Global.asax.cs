using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Forum.UI.App_Start;
using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using Unity;
using Unity.Mvc5;


namespace Forum.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            //GlobalFilters.Filters.Add(new ForumAuthorizeAttribute());
            
            EFConfig.Initialize();
            UnityConfig.Container.Resolve<IDataSeedService>().SeedData();
        }

      





    }
}
