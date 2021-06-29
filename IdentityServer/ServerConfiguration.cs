using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public class ServerConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("icarapi", "Icar api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "web",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("icar".Sha256()) },
                    AllowedScopes = { "icarapi" }
                }
            };
    }
}
