using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public interface IStorageService
    {
        Task UploadPictureAsync(string url, string base64);
        Task DeletePictureAsync(string url);
    }
}
