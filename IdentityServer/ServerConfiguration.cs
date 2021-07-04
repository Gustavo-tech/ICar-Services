using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public class ServerConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("Api")
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
