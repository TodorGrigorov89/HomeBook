namespace HomeBook.Web.Controllers
{
    using System.Threading.Tasks;

    using HomeBook.Services.Data.BlogPosts;
    using HomeBook.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Mvc;

    public class BlogPostsController : BaseController
    {
        private readonly IBlogPostsService blogPostsService;

        public BlogPostsController(IBlogPostsService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BlogPostListViewModel
            {
                BlogPosts = await this.blogPostsService.GetAllAsync<BlogPostViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> SinglePost(int id)
        {
            var viewModel = await this.blogPostsService.GetByIdAsync<BlogPostViewModel>(id);

            if (viewModel == null)
            {
                return this.Redirect("/Home/Error404");
            }

            return this.View(viewModel);
        }
    }
}
