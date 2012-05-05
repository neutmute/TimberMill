using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Wcf;
using NLog;

namespace TimberMill.Service
{
    public class Global : System.Web.HttpApplication
    {

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        protected void Application_Start(object sender, EventArgs e)
        {
            Log.Info("-------------------------------------------------------------------------------------------------------");
            ComposeAutofac();

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

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