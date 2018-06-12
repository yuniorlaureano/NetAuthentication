using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WindowsAuthentication.Startup))]

namespace WindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseWindowsAuthentication();
            app.UseClaimsTransformation(Transformation);
            app.UseWebApi(WebApiConfig.Register());
        }

        private async Task<ClaimsPrincipal> Transformation(ClaimsPrincipal incoming)
        {
            if (!incoming.Identity.IsAuthenticated)
            {
                return incoming;
            }

            var name = incoming.Identity.Name;
            //got to a datastore find the app specific claims

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, name),
                new Claim(ClaimTypes.Role, "foo"),
                new Claim(ClaimTypes.Email, "foo@foo.com")

            };

            var id = new ClaimsIdentity("Windows");
            id.AddClaims(claims);

            return new ClaimsPrincipal(id);

        }
    }
}
