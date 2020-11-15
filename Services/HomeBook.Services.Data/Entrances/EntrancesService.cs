namespace HomeBook.Services.Data.Entrances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Entrances;
    using Microsoft.EntityFrameworkCore;

    public class EntrancesService : IEntrancesService
    {
        private readonly IDeletableEntityRepository<Entrance> entrancesRepository;

        public EntrancesService(IDeletableEntityRepository<Entrance> entrancesRepository)
        {
            this.entrancesRepository = entrancesRepository;
        }

        public async Task AddAsync(EntranceInputModel entranceInputModel)
        {
            var entrance = new Entrance
            {
                EntranceAddressSign = entranceInputModel.EntranceAddressSign,
                BuildingId = entranceInputModel.BuildingId,
            };

            bool doesEntranceExist = await this.entrancesRepository.All().AnyAsync(x => x.EntranceAddressSign == entrance.EntranceAddressSign);

            if (doesEntranceExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.StreetNameAlreadyExists, entrance.EntranceAddressSign));
            }

            await this.entrancesRepository.AddAsync(entrance);
            await this.entrancesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var entrances =
                await this.entrancesRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return entrances;
        }

        public async Task DeleteAsync(int id)
        {
            var entrance =
                await this.entrancesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.entrancesRepository.Delete(entrance);
            await this.entrancesRepository.SaveChangesAsync();
        }
    }
}
