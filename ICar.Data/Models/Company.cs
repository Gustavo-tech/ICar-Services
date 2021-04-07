using ICar.Data.Models.Abstract;

namespace ICar.Data.Models
{
    public sealed class Company : Entity
    {
        public int Id { get; }
        public string Cnpj { get; }
    }
}
