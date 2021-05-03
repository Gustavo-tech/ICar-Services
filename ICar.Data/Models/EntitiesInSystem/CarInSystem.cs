using ICar.Data.Converter;
using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Enums.Car;
using ICar.Data.Queries;
using ICar.Data.Queries.Contracts;

namespace ICar.Data.Models.EntitiesInSystem
{
    public class CarInSystem : AbstractCar
    {
        private readonly IUserQueries _userQueries = new UserQueries();
        private readonly ICompanyQueries _companyQueries = new CompanyQueries();
        private readonly ICityQueries _cityQueries = new CityQueries();

        public TypeOfExchange TypeOfExchange { get; }
        public Color Color { get; }
        public GasolineType GasolineType { get; }
        public CityInSystem City { get; set; }
        public UserInSystem User { get; set; }
        public CompanyInSystem Company { get; set; }
        public int NumberOfViews { get; set; }

        public CarInSystem(string plate, string maker, string model,
            int make_year, int maked_year, double kilometers,
            string type_of_exchange, double price, Color color,
            bool accepts_change, bool ipva_is_paid, bool is_licensed,
            GasolineType gasoline_type, bool is_armored, string message,
            int city_id, string user_cpf, string company_cnpj)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = make_year;
            MakedDate = maked_year;
            KilometersTraveled = kilometers;
            TypeOfExchange = CarPropertyConverter.ConvertStringToTypeOfExchange(type_of_exchange);
            Price = price;
            Color = color;
            AcceptsChange = accepts_change;
            IpvaIsPaid = ipva_is_paid;
            IsLicensed = is_licensed;
            GasolineType = gasoline_type;
            IsArmored = is_armored;
            Message = message;
            City = _cityQueries.GetCityById(city_id);
            User = _userQueries.GetUserByCpf(user_cpf);
            Company = _companyQueries.GetCompanyByCnpj(company_cnpj);
        }
    }
}
