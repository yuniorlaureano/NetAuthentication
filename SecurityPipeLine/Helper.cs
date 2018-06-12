using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SecurityPipeLine
{
    public class Helper
    {
        public static void Write(string stage, IPrincipal principal)
        {
            Debug.WriteLine("--------------"+ stage +"--------------");
            if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated)
            {
                Debug.WriteLine("Anonymous use");
            }
            else
            {
                Debug.WriteLine("User: " + principal.Identity.Name);
            }

            Debug.WriteLine("\n");
        }
    }
}