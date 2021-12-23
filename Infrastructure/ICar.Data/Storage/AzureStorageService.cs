using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ICar.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public class AzureStorageService : IStorageService
    {
        private readonly BlobContainerClient _container;

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

        public async Task UploadCarPicturesAsync(Car car, string[] pictures)
        {
            if (car is null || pictures is null)
                return;

            for (int i = 0; i < pictures.Length; i++)
            {
                string url = car.Pictures[i].GenerateStoragePath();
                string base64 = pictures[i];
                await UploadPictureAsync(url, base64);
            }
        }

        public async Task DeleteBlobAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            await _container.DeleteBlobIfExistsAsync(url);
        }
    }
}
