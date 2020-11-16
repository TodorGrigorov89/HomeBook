namespace HomeBook.Services.Data.Apartments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Apartments;

    public interface IApartmentsService
    {
        Task AddAsync(ApartmentInputModel apartmentInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
