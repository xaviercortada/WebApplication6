using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using Microsoft.IdentityModel.Tokens; 
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace WebApiTest
{
    public partial class Startup
    {
        // Para obtener más información sobre cómo configurar la autenticación, visite https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseActiveDirectoryFederationServicesBearerAuthentication(
                        new ActiveDirectoryFederationServicesBearerAuthenticationOptions
                        {
                            MetadataEndpoint = ConfigurationManager.AppSettings["ida:AdfsMetadataEndpoint"],
                            TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                                // ValidIssuer = ConfigurationManager.AppSettings["ida:Issuer"]
                            }
                        }
             );
        }
    }
}
