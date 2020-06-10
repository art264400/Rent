using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LightInject;
using Rent.Interfaces;
using Rent.Services;

namespace Rent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            container.Register<IRentService, EntityRentService>(new PerRequestLifeTime());
            container.EnableMvc();
        }
    }
}
