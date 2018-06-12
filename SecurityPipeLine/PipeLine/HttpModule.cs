using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityPipeLine.PipeLine
{
    public class HttpModule : IHttpModule
    {
        void contextBiginRequest(object sender, EventArgs e)
        {
            Helper.Write("HttpModule", HttpContext.Current.User);
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += contextBiginRequest;
        }

        public void Dispose()
        {
            
        }
    }
}