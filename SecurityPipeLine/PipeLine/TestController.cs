using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SecurityPipeLine.PipeLine
{
    [TestAuthenticationFilter]
    [TestAuthorizationFilter]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            Helper.Write("Controller", User);
            return Ok();
        }
    }
}