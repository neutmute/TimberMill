using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using NLog;
using TimberMill.Data;
using TimberMill.Domain.Service;
using Module = Autofac.Module;

namespace TimberMill.Service
{
    public class AutofacModule : Module
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            Log.Trace("Registering TimberMill.Service module");

            var dataAssembly = typeof(TimberMillDbContext).Assembly;
            var domainAssembly = typeof(LogService).Assembly;

            builder.RegisterAssemblyTypes(dataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(domainAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsSelf();

            builder.Register(
                c => new TimberMillService(c.Resolve<LogService>()))
                .InstancePerDependency()
                .As<TimberMillService>();

        }
    }
}