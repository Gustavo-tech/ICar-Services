using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Models
{
    public class CarPicture
    {
        public int? Id { get; set; }
        public string Picture { get; set; }
        public Car Car { get; set; }

        public CarPicture()
        {
        }
    }
}
