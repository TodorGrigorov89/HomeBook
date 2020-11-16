namespace HomeBook.Services.Data.UsersDocuments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.UsersDocuments;

    public interface IUsersDocumentsService
    {
        Task AddAsync(UserDocumentInputModel userDocumentInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
