namespace HomeBook.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Documents;

    public interface IDocumentsService
    {
        Task AddAsync(DocumentInputModel documentInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
