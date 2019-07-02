using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace backend.Web
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://localhost:8080", "*", "*");

            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
        }
    }
}