using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Wcf;
using NLog;

namespace TimberMill.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            Log.Info("-------------------------------------------------------------------------------------------------------");
            ComposeAutofac();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void ComposeAutofac()
        {
            //// WCF
            var builder = new ContainerBuilder();

            // Assembly.LoadFrom was locking the dll's and couldn't recompile. bye bye fancy shit.

            builder.RegisterModule(new AutofacModule());

            var container = builder.Build();

            //// WCF
            AutofacHostFactory.Container = container;

            // MVC
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}