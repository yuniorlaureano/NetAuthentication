using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WindowsAuthentication.Middleware
{
    public class ClaimsTransformationMiddleware
    {
        private readonly ClaimsTransformationOptions _options;
        private readonly Func<IDictionary<string, object>, Task> _next;

        public ClaimsTransformationMiddleware(Func<IDictionary<string, object>, Task> next, ClaimsTransformationOptions options)
        {
            this._next = next;
            this._options = options;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);

            if (context.Authentication != null && context.Authentication.User != null)
            {
                var transformedPrincipal = await this._options.ClaimsTransformation(context.Authentication.User);
                context.Authentication.User = new ClaimsPrincipal(transformedPrincipal);
            }

            await _next(env);
        }
    }
}