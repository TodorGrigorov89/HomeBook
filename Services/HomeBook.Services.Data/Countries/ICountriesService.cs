namespace HomeBook.Services.Data.Countries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountriesService
    {
        Task AddAsync(string name);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
