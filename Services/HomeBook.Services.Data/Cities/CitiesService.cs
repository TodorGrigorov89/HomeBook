namespace HomeBook.Services.Data.Cities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task AddAsync(string name, int countryId)
        {
            await this.citiesRepository.AddAsync(new City
            {
                Name = name,
                CountryId = countryId,
            });
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
