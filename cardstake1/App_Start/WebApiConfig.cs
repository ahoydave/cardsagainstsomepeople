using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cardstake1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "CardApi",
            //    routeTemplate: "api/{controller}/{type}",
            //    defaults: new { type = "A" }
            //);
        }
    }
}
