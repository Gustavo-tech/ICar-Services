using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ICar.Infrastructure.Models
{
    public class CarPicture : Entity
    {
        private string _pictureUrl;

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Picture content can't be null");

                _pictureUrl = value;
            }
        }

        private CarPicture()
        {
        }

        public CarPicture(string userName, string carId, string base64)
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Contains(" "))
                throw new InvalidOperationException("User name is not valid");

            else if (string.IsNullOrWhiteSpace(carId) || carId.Contains(" "))
                throw new InvalidOperationException("Car id is not valid");

            Id = GenerateId();
            string extension = GetPictureExtension(base64);
            PictureUrl = $"https://icarstorage.blob.core.windows.net/users/{userName}/cars/{carId}/{Id}.{extension}";
        }

        public string GenerateStoragePath()
        {
            return PictureUrl.Replace("https://icarstorage.blob.core.windows.net/users/", "");
        }

        public static string GetPictureExtension(string base64)
        {
            if (base64 is null)
                return null;

            Regex rgx = new("(/.*;)", RegexOptions.IgnoreCase);
            Match match = rgx.Match(base64);

            StringBuilder sb = new(match.Value);
            sb.Replace("/", "");
            sb.Replace(";", "");

            return sb.ToString();
        }
    }
}
