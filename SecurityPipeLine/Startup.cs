using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SecurityPipeLine.PipeLine;

[assembly: OwinStartup(typeof(SecurityPipeLine.Startup))]

namespace SecurityPipeLine
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                "default",
                "api/{controller}"
                );

            
           

            app.Use(typeof(TestMiddleware));

            app.UseWebApi(configuration);
        }
    }
}
