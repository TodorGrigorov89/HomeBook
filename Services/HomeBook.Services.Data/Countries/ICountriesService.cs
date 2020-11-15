namespace HomeBook.Services.Data.Countries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Countries;

    public interface ICountriesService
    {
        Task AddAsync(CountryInputModel countryInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
