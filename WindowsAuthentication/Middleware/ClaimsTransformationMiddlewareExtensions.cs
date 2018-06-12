using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using Owin;
using System.Threading.Tasks;

namespace WindowsAuthentication.Middleware
{
    public static class ClaimsTransformationMiddlewareExtensions
    {
        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, Func<ClaimsPrincipal, Task<ClaimsPrincipal>> transformation)
        {
            return app.UseClaimsTransformation(new ClaimsTransformationOptions
            {
                ClaimsTransformation = transformation
            });
        }

        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, ClaimsTransformationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(ClaimsTransformationMiddleware), options);
            return app;
        }
    }
}