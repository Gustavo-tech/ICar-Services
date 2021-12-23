using ICar.Infrastructure.Models;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public interface IStorageService
    {
        Task UploadPictureAsync(string url, string base64);
        Task UploadCarPicturesAsync(Car car, string[] pictures);
        Task DeleteBlobAsync(string url);
    }
}
