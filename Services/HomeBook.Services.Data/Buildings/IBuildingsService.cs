namespace HomeBook.Services.Data.Buildings
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Buildings;

    public interface IBuildingsService
    {
        Task AddAsync(BuildingInputModel buildingInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
