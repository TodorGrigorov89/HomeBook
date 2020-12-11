namespace HomeBook.Services.Data.BlogPosts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.BlogPosts;

    public interface IBlogPostsService
    {
        Task AddAsync(BlogPostInputModel blogPostInputModel);

        Task<T> GetByIdAsync<T>(int id);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();
    }
}
