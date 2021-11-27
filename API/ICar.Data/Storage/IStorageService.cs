using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Storage
{
    public interface IStorageService
    {
        Task UploadPicture(Car car, string pictureId, string base64);
        Task DeletePicture(string userName, string carId, string pictureId);
    }
}
