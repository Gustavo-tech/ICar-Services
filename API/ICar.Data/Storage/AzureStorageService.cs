using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using Azure.Storage.Blobs.Models;
using ICar.Infrastructure.Models;

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

        public async Task UploadPictureAsync(string url, string completeBase64)
        {
            string extension = CarPicture.GetPictureExtension(completeBase64);
            completeBase64 = completeBase64.Split("base64,")[1];

            byte[] bytes = Convert.FromBase64String(completeBase64);
            MemoryStream ms = new(bytes);

            BlobClient bc = _container.GetBlobClient(url);
            await bc.UploadAsync(ms, new BlobHttpHeaders
            {
                ContentType = $"image/{extension}"
            });
        }

        public async Task DeletePictureAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            await _container.DeleteBlobIfExistsAsync(url);
        }
    }
}
