using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Samples.WebApi
{
    public class Startup
    {
        private HttpConfiguration config;

        public Startup() => config = new HttpConfiguration();

        public void Configuration(IAppBuilder app)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            this.ConfigureOAuth(app);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var options = new OAuthAuthorizationServerOptions
            {
                Provider = new ServerProvider(), /* we can use any kind of providers.. facebook twitter etc.. */
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                TokenEndpointPath = new PathString("/api/security/token")
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}