namespace HomeBook.Services.Data.Buildings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BuildingsService : IBuildingsService
    {
        private readonly IDeletableEntityRepository<Building> buildingsRepository;

        public BuildingsService(IDeletableEntityRepository<Building> buildingsRepository)
        {
            this.buildingsRepository = buildingsRepository;
        }

        public async Task AddAsync(string entranceSign, int numberOfEntrances, int numberOfFloors, int streetId)
        {
            await this.buildingsRepository.AddAsync(new Building
            {
                EntranceSign = entranceSign,
                NumberOfEntrances = numberOfEntrances,
                NumberOfFloors = numberOfFloors,
                StreetId = streetId,
            });
            await this.buildingsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var buildings =
                await this.buildingsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return buildings;
        }

        public async Task DeleteAsync(int id)
        {
            var building =
                await this.buildingsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.buildingsRepository.Delete(building);
            await this.buildingsRepository.SaveChangesAsync();
        }
    }
}
