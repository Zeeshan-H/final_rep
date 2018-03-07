using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace api_postman
{
    public class MyAuthServiceProvider : OAuthAuthorizationServerProvider 
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if (context.UserName == "user" && context.Password == "user")
            {

                identity.AddClaim(new Claim(ClaimTypes.Role, "tutors"));
                identity.AddClaim(new Claim("username", "tutors"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hamza Awais"));
                context.Validated(identity);
            }
            else if (context.UserName == "admin" && context.Password == "admin")
            {

                identity.AddClaim(new Claim(ClaimTypes.Role, "students"));
                identity.AddClaim(new Claim("username", "students"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Zeeshan Haider"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid_grant!","Provided username and password is incorrect!");
                return;
            }





        }



    }
}
