namespace HomeBook.Services.Data.UsersApartments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.UsersApartments;

    public interface IUsersApartmentsService
    {
        Task AddAsync(UserApartmentInputModel userApartmentInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
