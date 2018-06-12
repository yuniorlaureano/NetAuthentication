using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace SecurityPipeLine.PipeLine
{
    public class TestMiddleware
    {
        public Func<IDictionary<string, object>, Task> _next;

        public TestMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);

            //authentication

            context.Request.User = new GenericPrincipal(new GenericIdentity("yunior"), new string[] { });

            Helper.Write("Middleware", context.Request.User);

            await _next(env);
        }

    }
}