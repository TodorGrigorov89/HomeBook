namespace HomeBook.Services.Data.Streets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Streets;
    using Microsoft.EntityFrameworkCore;

    public class StreetsService : IStreetsService
    {
        private readonly IDeletableEntityRepository<Street> streetsRepository;

        public StreetsService(IDeletableEntityRepository<Street> streetsRepository)
        {
            this.streetsRepository = streetsRepository;
        }

        public async Task AddAsync(StreetInputModel streetInputModel)
        {
            var street = new Street
            {
                Name = streetInputModel.Name,
                CityId = streetInputModel.CityId,
            };

            bool doesStreetExist = await this.streetsRepository.All().AnyAsync(x => x.Name == street.Name);
            bool doesStreetWithCurrentCityIdExist = await this.streetsRepository.All().AnyAsync(x => x.Name == street.Name && x.CityId == street.CityId);

            if (doesStreetExist)
            {
                if (!doesStreetWithCurrentCityIdExist)
                {
                }
                else
                {
                    throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.CityNameAlreadyExists, street.Name));
                }
            }

            await this.streetsRepository.AddAsync(street);
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
