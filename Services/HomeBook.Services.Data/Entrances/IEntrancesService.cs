namespace HomeBook.Services.Data.Entrances
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Entrances;

    public interface IEntrancesService
    {
        Task AddAsync(EntranceInputModel entranceInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
