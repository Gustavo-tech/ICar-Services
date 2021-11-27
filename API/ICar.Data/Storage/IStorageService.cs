using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public interface IStorageService
    {
        Task UploadPicture(string url, string base64);
        Task DeletePicture(string url);
    }
}
