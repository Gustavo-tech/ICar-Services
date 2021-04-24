using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.ViewModels {
    public class CompanyCnpj {
        public string Cnpj { get; set; }

        public CompanyCnpj(string cnpj) {
            Cnpj = cnpj;
        }
    }
}
