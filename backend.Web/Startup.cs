using Autofac.Integration.WebApi;
using Owin;
using Microsoft.Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(backend.Web.Startup))]
namespace backend.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region autofac
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container.Get);
            app.UseAutofacMiddleware(container.Get);
            #endregion

            #region web api
            app.UseAutofacWebApi(config);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            #endregion
        }

        #region private fields
        private readonly HttpConfiguration config = new HttpConfiguration();
        private readonly Container container = new Container();
        #endregion
    }
}