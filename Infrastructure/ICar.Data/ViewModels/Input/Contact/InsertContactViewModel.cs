using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Input
{
    public class InsertContactViewModel
    {
        public string EmailAddress { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
