namespace HomeBook.Services.Data.Buildings
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBuildingsService
    {
        Task AddAsync(string entranceSign, int numberOfEntrances, int numberOfFloors, int streetId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
