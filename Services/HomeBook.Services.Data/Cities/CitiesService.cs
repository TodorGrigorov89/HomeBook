namespace HomeBook.Services.Data.Cities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task AddAsync(CityInputModel cityInputModel)
        {
            var city = new City
            {
                Name = cityInputModel.Name,
                CountryId = cityInputModel.CountryId,
            };

            bool doesCityExist = await this.citiesRepository.All().AnyAsync(x => x.Name == city.Name);
            bool doesCityWithCurrentCountryIdExist = await this.citiesRepository.All().AnyAsync(x => x.Name == city.Name && x.CountryId == city.CountryId);

            if (doesCityExist)
            {
                if (!doesCityWithCurrentCountryIdExist)
                {
                }
                else
                {
                    throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.CityNameAlreadyExists, city.Name));
                }
            }

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cities =
                await this.citiesRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return cities;
        }

        public async Task DeleteAsync(int id)
        {
            var city =
                await this.citiesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.citiesRepository.Delete(city);
            await this.citiesRepository.SaveChangesAsync();
        }
    }
}
