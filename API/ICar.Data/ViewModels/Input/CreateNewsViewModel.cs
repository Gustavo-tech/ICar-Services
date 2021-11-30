using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Input
{
    public class CreateNewsViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserEmail { get; set; }
    }
}
