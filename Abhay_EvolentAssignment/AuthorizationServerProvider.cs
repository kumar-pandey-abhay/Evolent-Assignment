using Microsoft.Owin.Security.OAuth;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Abhay_EvolentAssignment
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            IUserService userService = new UserService();
            if (userService.ValidateUser(context.Parameters["username"], context.Parameters["password"]))
            {
                context.Validated();
            }
            else
            {
                context.SetError("invalid_grant", "Wrong credentials Used. Please Try again");
                return;
            }
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new CaimsIdentity(context.Options.AuthenticationType);
            
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(identity);
        }
    }
}