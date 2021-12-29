using Azure.Identity;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GraphServiceClient _graphClient;

        public UserRepository(IConfiguration configuration)
        {
            string[] scopes = { "User.ReadWrite.All" };
            string tenantId = configuration["AzureAdB2C:TenantId"];
            string clientId = configuration["AzureAdB2C:ClientId"];

            TokenCredentialOptions options = new()
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            Func<DeviceCodeInfo, CancellationToken, Task> callback = (code, cancellation) => 
            {
                Console.WriteLine(code.Message);
                return Task.FromResult(0);
            };

            DeviceCodeCredential codeCredential = new(callback, tenantId, clientId, options);
            _graphClient = new GraphServiceClient(codeCredential, scopes);
        }

        public async Task<User> GetUserInfo(string userId)
        {
            return await _graphClient.Users[userId]
                .Request()
                .Select("displayName,phone,userPrincipalName")
                .GetAsync();
        }
    }
}
