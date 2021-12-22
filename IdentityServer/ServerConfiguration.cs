﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ICar.IdentityServer
{
    public class ServerConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "web",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("icar".Sha256()) },
                    AllowedScopes =
                    {
                        "Api",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                    },
                    RedirectUris =
                    {
                        "http://localhost:3000/authentication/callback",
                        "http://localhost:3000/authentication/silent_callback",
                        "https://oauth.pstmn.io/v1/callback"
                    },
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AccessTokenLifetime = 86400,
                    IdentityTokenLifetime = 86400,
                    AlwaysSendClientClaims = true
                }
            };
    }
}
