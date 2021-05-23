﻿using ICar.Data.Models.Entities;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByIdAsync(int id);
        Task InsertCityAsync(City city);
    }
}