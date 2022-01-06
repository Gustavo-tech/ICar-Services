﻿using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarContext _dbContext;

        public CarRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetCarByIdAsync(string id)
        {
            return await _dbContext.Cars
                .Where(x => x.Id == id)
                .Include(x => x.Address)
                .Include(x => x.Pictures)
                .FirstOrDefaultAsync();
        }

        public async Task<Car> GetCarByPlateAsync(string plate)
        {
            return await _dbContext.Cars
                .Where(x => x.Plate == plate)
                .Include(x => x.Address)
                .Include(x => x.Pictures)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarsAsync(CarSearchModel search)
        {
            List<Car> cars = await _dbContext.Cars
                .Include(x => x.Pictures)
                .Include(x => x.Address)
                .ToListAsync();

            if (search is null)
                return cars;

            if (search.Maker is not null)
                cars = cars.Where(x => x.Maker == search.Maker).ToList();

            if (search.Model is not null)
                cars = cars.Where(x => x.Model == search.Model).ToList();

            if (search.MinPrice is not null)
                cars = cars.Where(x => x.Price >= search.MinPrice.Value).ToList();

            if (search.MaxPrice is not null)
                cars = cars.Where(x => x.Price <= search.MaxPrice.Value).ToList();

            if (search.MaxKilometers is not null)
                cars = cars.Where(x => x.KilometersTraveled <= search.MaxKilometers.Value).ToList();

            return cars;
        }

        public async Task<List<Car>> GetMostSeenCarsAsync(int quantity)
        {
            return await _dbContext.Cars
                .OrderBy(x => x.NumberOfViews)
                .Take(quantity)
                .Include(x => x.Pictures)
                .Include(x => x.Address)
                .ToListAsync();
        }

        public async Task<string[]> GetMostSeenMakers(int quantity)
        {
            List<string> makers = new();
            List<Car> cars = await GetCarsAsync(null);
            List<string> allMakers = cars.Select(x => x.Maker).Distinct().ToList();
            List<int> views = new();

            foreach(string maker in allMakers)
            {
                int totalMakerViews = cars.Where(x => string.Equals(x.Maker, maker, StringComparison.OrdinalIgnoreCase))
                    .Sum(x => x.NumberOfViews);

                if (views.Count < quantity)
                {
                    views.Add(totalMakerViews);
                    makers.Add(maker);
                }

                else
                {
                    int minimumNumber = views.Min();

                    if(totalMakerViews > minimumNumber)
                    {
                        int index = views.IndexOf(minimumNumber);
                        views[index] = totalMakerViews;
                        makers[index] = maker;
                    }
                }
            }

            return makers.ToArray();
        }

        public async Task<List<Car>> GetUserCarsAsync(string ownerId)
        {
            return await _dbContext.Cars
                .Where(x => x.OwnerId == ownerId)
                .Include(x => x.Pictures)
                .Include(x => x.Address)
                .ToListAsync();
        }
    }
}
