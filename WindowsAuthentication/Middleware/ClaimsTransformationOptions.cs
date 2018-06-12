using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WindowsAuthentication.Middleware
{
    public class ClaimsTransformationOptions
    {
        public Func<ClaimsPrincipal, Task<ClaimsPrincipal>> ClaimsTransformation { get; set; }
    }
}