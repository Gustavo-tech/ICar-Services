using Azure.Storage.Blobs;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public sealed class CarPictureStorageAccessor
    {
        private CloudBlobContainer _carContainer;

        public CarPictureStorageAccessor()
        {
            string connectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();

            _carContainer = client.GetContainerReference("car");
        }

        public async Task UploadPicturesAsync(string carPlate, List<string> pictures)
        {
            CloudBlobDirectory blobDirectory = _carContainer.GetDirectoryReference(carPlate);

            for (int i = 0; i < pictures.Count; i++)
            {
                CloudBlockBlob blob = blobDirectory.GetBlockBlobReference($"{carPlate}-{i}");
            }
        }
    }
}
