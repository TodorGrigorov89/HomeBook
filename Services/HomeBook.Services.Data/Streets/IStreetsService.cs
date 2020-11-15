namespace HomeBook.Services.Data.Streets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Streets;

    public interface IStreetsService
    {
        Task AddAsync(StreetInputModel streetInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
