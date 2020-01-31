using Autofac;
using DomainLayer.BusinessLogic;
using SampleDI.AppLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleDI
{
    public static class Bootstrap
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Startup>();
            builder.RegisterType<Config>().As<IConfig>();
            builder.RegisterType<Util>().As<IUtil>();
            builder.RegisterType<Operations>().As<IOperations>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DomainLayer)))
                .Where(t => t.Namespace.Contains("Fork"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
