namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.BlogPosts;
    using HomeBook.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Mvc;

    public class BlogPostsController : AdministrationController
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

        public IActionResult AddBlogPost()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogPost(BlogPostInputModel blogPostInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(blogPostInputModel);
            }

            try
            {
                await this.blogPostsService.AddAsync(blogPostInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", blogPostInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.BlogPosts)
            {
                return this.RedirectToAction("Index");
            }

            await this.blogPostsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
