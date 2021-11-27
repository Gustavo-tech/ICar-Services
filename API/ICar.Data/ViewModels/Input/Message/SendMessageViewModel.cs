using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Input.Message
{
    public class SendMessageViewModel
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Text { get; set; }
    }
}
