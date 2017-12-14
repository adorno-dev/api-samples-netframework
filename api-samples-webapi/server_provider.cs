using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Api.Samples.WebApi
{
    public class ServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) => Task.FromResult(context.Validated());

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var who = new { Username = context.UserName, context.Password };

            if (!who.Username.Equals("usr") || !who.Password.Equals("pwd"))
            {
                context.SetError("invalid_grant", "Invalid username or password!");
                return;
            }

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var claims = new Dictionary<string, Claim>();

                claims.Add(ClaimTypes.Name, new Claim(ClaimTypes.Name, who.Username));
                claims.Add("Admin", new Claim(ClaimTypes.Role, "Admin"));
                claims.Add("User", new Claim(ClaimTypes.Role, "User"));

                identity.AddClaim(claims[ClaimTypes.Name]);
                identity.AddClaim(claims["User"]);
                //identity.AddClaim(claims["Admin"]);

                Thread.CurrentPrincipal = new GenericPrincipal(identity, 
                    claims.Where(w => w.Value.Type == ClaimTypes.Role).Select(s => s.Key).ToArray()); /* all role keys */

                await Task.FromResult(context.Validated(identity: identity));

            }
            catch
            {
                context.SetError("invalid_grant", "Authentication failed!");
            }

        }
    }
}