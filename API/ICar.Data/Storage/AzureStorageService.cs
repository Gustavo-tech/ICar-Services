using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;

namespace ICar.Infrastructure.Storage
{
    public class AzureStorageService : IStorageService
    {
        private BlobContainerClient _container;

        public AzureStorageService(IConfiguration configuration)
        {
            string storageConnection = configuration.GetConnectionString("AzureStorage");
            BlobServiceClient client = new(storageConnection);
            _container = client.GetBlobContainerClient("users");
        }

        public async Task UploadPictureAsync(string url, string base64)
        {
            if (base64.Contains("base64,"))
                base64 = base64.Split("base64,")[1];

            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream ms = new(bytes);
            await _container.UploadBlobAsync(url, ms);
        }

        public async Task DeletePictureAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            await _container.DeleteBlobIfExistsAsync(url);
        }
    }
}
