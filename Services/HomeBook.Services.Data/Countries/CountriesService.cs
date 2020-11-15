namespace HomeBook.Services.Data.Countries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.EntityFrameworkCore;

    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countriesRepository;

        public CountriesService(IDeletableEntityRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task AddAsync(CountryInputModel countryInputModel)
        {
            var country = new Country
            {
                Name = countryInputModel.Name,
            };

            bool doesCountryExist = await this.countriesRepository.All().AnyAsync(x => x.Name == country.Name);

            if (doesCountryExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.CountryNameAlreadyExists, country.Name));
            }

            await this.countriesRepository.AddAsync(country);
            await this.countriesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var countries =
                await this.countriesRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return countries;
        }

        public async Task DeleteAsync(int id)
        {
            var country =
                await this.countriesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.countriesRepository.Delete(country);
            await this.countriesRepository.SaveChangesAsync();
        }
    }
}
