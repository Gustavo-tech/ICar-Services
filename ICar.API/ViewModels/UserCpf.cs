using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.ViewModels {
    public class UserCpf {
        public string Cpf { get; set; }

        public UserCpf(string cpf) {
            Cpf = cpf;
        }
    }
}
