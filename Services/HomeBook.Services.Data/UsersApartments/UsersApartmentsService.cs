namespace HomeBook.Services.Data.UsersApartments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.UsersApartments;
    using Microsoft.EntityFrameworkCore;

    public class UsersApartmentsService : IUsersApartmentsService
    {
        private readonly IDeletableEntityRepository<UserApartment> usersApartmentsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;

        public UsersApartmentsService(
            IDeletableEntityRepository<UserApartment> usersApartmentsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Apartment> apartmentsRepository)
        {
            this.usersApartmentsRepository = usersApartmentsRepository;
            this.usersRepository = usersRepository;
            this.apartmentsRepository = apartmentsRepository;
        }

        public async Task AddAsync(UserApartmentInputModel userApartmentInputModel)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userApartmentInputModel.ApplicationUserId);

            if (user == null)
            {
                throw new NullReferenceException(
                    string.Format(GlobalConstants.ErrorMessages.UserNotFound, user.Id));
            }

            var apartment = await this.apartmentsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userApartmentInputModel.ApartmentId);

            if (apartment == null)
            {
                throw new NullReferenceException(
                    string.Format(GlobalConstants.ErrorMessages.ApartmentNotFound, apartment.Id));
            }

            var userApartment = new UserApartment
            {
                ApplicationUserId = userApartmentInputModel.ApplicationUserId,
                ApartmentId = userApartmentInputModel.ApartmentId,
            };

            bool doesUserApartmentExist = await this.usersApartmentsRepository
                .All()
                .AnyAsync(x => x.ApplicationUserId == userApartment.ApplicationUserId &&
                          x.ApartmentId == userApartment.ApartmentId);

            if (doesUserApartmentExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.UserApartmentExists, userApartment.ApplicationUserId, userApartment.ApartmentId));
            }

            await this.usersApartmentsRepository.AddAsync(userApartment);
            await this.usersApartmentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var userApartments =
                await this.usersApartmentsRepository
                .All()
                .OrderBy(x => x.ApplicationUserId)
                .To<T>().ToListAsync();

            return userApartments;
        }
    }
}
