namespace HomeBook.Services.Data.Apartments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ApartmentsService : IApartmentsService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;

        public ApartmentsService(IDeletableEntityRepository<Apartment> apartmentsRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
        }

        public async Task AddAsync(string apartmentNumber, int floor, int numberOfResidents, decimal area, int buildingId)
        {
            await this.apartmentsRepository.AddAsync(new Apartment
            {
                ApartmentNumber = apartmentNumber,
                Floor = floor,
                NumberOfResidents = numberOfResidents,
                Area = area,
                BuildingId = buildingId,
            });
            await this.apartmentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var apartments =
                await this.apartmentsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return apartments;
        }

        public async Task DeleteAsync(int id)
        {
            var apartment =
                await this.apartmentsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.apartmentsRepository.Delete(apartment);
            await this.apartmentsRepository.SaveChangesAsync();
        }
    }
}
