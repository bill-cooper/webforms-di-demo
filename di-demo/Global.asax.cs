using di_demo.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace di_demo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var collection = new ServiceCollection();
            collection.AddScoped<IPersonRepository, EmployeeRepository>();
            var provider = new di_demo.Services.ServiceProvider(collection.BuildServiceProvider());
            HttpRuntime.WebObjectActivator = provider;
        }
    }

    public class Dependency: IDependency
    {
    }

    public interface IDependency
    {
    }
}