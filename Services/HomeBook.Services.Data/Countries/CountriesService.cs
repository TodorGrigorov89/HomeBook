namespace HomeBook.Services.Data.Countries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countriesRepository;

        public CountriesService(IDeletableEntityRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task AddAsync(string name)
        {
            await this.countriesRepository.AddAsync(new Country
            {
                Name = name,
            });
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
