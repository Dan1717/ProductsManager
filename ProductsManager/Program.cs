using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace ProductsManager
{
    public class Program
    {
        static Container container;
        static Program()
        {
            container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //container.Register<IOrderRepository, SqlOrderRepository>();
            //container.Register<ILogger, FileLogger>(Lifestyle.Singleton);
            //container.Register<CancelOrderHandler>();
            //container.Verify();
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
