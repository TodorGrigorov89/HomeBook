namespace HomeBook.Services.Data.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Buildings;
    using Microsoft.EntityFrameworkCore;

    public class BuildingsService : IBuildingsService
    {
        private readonly IDeletableEntityRepository<Building> buildingsRepository;

        public BuildingsService(IDeletableEntityRepository<Building> buildingsRepository)
        {
            this.buildingsRepository = buildingsRepository;
        }

        public async Task AddAsync(BuildingInputModel buildingInputModel)
        {
            var building = new Building
            {
                BuildingFullAddress = buildingInputModel.BuildingFullAddress,
                NumberOfEntrances = buildingInputModel.NumberOfEntrances,
                NumberOfFloors = buildingInputModel.NumberOfFloors,
                NumberOfApartments = buildingInputModel.NumberOfApartments,
                StreetId = buildingInputModel.StreetId,
            };

            bool doesBuildingExist = await this.buildingsRepository.All().AnyAsync(x => x.BuildingFullAddress == building.BuildingFullAddress);

            if (doesBuildingExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.StreetNameAlreadyExists, building.BuildingFullAddress));
            }

            await this.buildingsRepository.AddAsync(building);
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
