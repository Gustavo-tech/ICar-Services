using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.OperationsExtension
{
    internal class CityOperationsExtension
    {
        private readonly ICityRepository _cityRepository;
        private readonly IBaseRepository _baseRepository;

        public CityOperationsExtension(ICityRepository cityRepository, IBaseRepository baseRepository)
        {
            _cityRepository = cityRepository;
            _baseRepository = baseRepository;
        }

        internal async Task<City> InsertCityIfDoesntExist(string cityName)
        {
            City cityInDatabase = await _cityRepository.GetCityAsync(cityName);

            if (cityName == null)
            {
                City newCity = new() { Name = cityName };
                await _baseRepository.AddAsync(newCity);
                return await _cityRepository.GetCityAsync(cityName);
            }
            else
                return cityInDatabase;
        }
    }
}
