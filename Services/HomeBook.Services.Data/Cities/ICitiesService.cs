namespace HomeBook.Services.Data.Cities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Cities;

    public interface ICitiesService
    {
        Task AddAsync(CityInputModel cityInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
