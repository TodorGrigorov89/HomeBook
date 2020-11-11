namespace HomeBook.Services.Data.Streets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class StreetsService : IStreetsService
    {
        private readonly IDeletableEntityRepository<Street> streetsRepository;

        public StreetsService(IDeletableEntityRepository<Street> streetsRepository)
        {
            this.streetsRepository = streetsRepository;
        }

        public async Task AddAsync(string name, string streetNumber, int cityId)
        {
            await this.streetsRepository.AddAsync(new Street
            {
                Name = name,
                StreetNumber = streetNumber,
                CityId = cityId,
            });
            await this.streetsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var streets =
                await this.streetsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return streets;
        }

        public async Task DeleteAsync(int id)
        {
            var street =
                await this.streetsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.streetsRepository.Delete(street);
            await this.streetsRepository.SaveChangesAsync();
        }
    }
}
