namespace HomeBook.Services.Data.Apartments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApartmentsService
    {
        Task AddAsync(string apartmentNumber, int floor, int numberOfResidents, decimal area, int buildingId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
