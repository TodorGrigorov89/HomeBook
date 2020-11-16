namespace HomeBook.Services.Data.Apartments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Apartments;
    using Microsoft.EntityFrameworkCore;

    public class ApartmentsService : IApartmentsService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;

        public ApartmentsService(IDeletableEntityRepository<Apartment> apartmentsRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
        }

        public async Task AddAsync(ApartmentInputModel apartmentInputModel)
        {
            var apartment = new Apartment
            {
                ApartmentNumber = apartmentInputModel.ApartmentNumber,
                Floor = apartmentInputModel.Floor,
                NumberOfResidents = apartmentInputModel.NumberOfResidents,
                Area = apartmentInputModel.Area,
                EntranceId = apartmentInputModel.EntranceId,
            };

            bool doesApartmentExist = await this.apartmentsRepository.All().AnyAsync(x => x.ApartmentNumber == apartment.ApartmentNumber);

            if (doesApartmentExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.ApartmentNumberExists, apartment.ApartmentNumber));
            }

            await this.apartmentsRepository.AddAsync(apartment);
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
