using Nancy;
using Nancy.Conventions;
using Owin;
using System.Web.Http;

namespace KatanaOwinBugTracker.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // SignalR
            app.MapSignalR();

            // ASP.NET Web API
            var config = new HttpConfiguration();       
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //  name: "DefaultApi",
            //  routeTemplate: "api/{controller}/{id}",
            //  defaults: new { id = RouteParameter.Optional });
            app.UseWebApi(config);

            // Nancy
            app.UseNancy(options =>
            {
                options.Bootstrapper = new NancyBootstrapper();
            });
        }
    }

    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            Conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("Scripts", "Scripts"));
        }
    }
}