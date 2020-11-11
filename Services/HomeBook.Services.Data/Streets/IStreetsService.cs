namespace HomeBook.Services.Data.Streets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStreetsService
    {
        Task AddAsync(string name, string streetNumber, int cityId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
