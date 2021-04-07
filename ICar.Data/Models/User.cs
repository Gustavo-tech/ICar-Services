using ICar.Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Models
{
    public sealed class User : Entity
    {
        public string Cpf { get; }
    }
}
