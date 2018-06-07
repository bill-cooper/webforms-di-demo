using di_demo.Data;
using di_demo.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace di_demo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var collection = new ServiceCollection();
            collection.AddScoped<IPersonRepository, EmployeeRepository>();
            collection.AddScoped<IYearProvider, YearProvider>();

            var provider = new di_demo.Services.ServiceProvider(collection.BuildServiceProvider());
            HttpRuntime.WebObjectActivator = provider;
        }
    }

}