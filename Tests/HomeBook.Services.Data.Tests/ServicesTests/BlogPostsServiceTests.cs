namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.BlogPosts;
    using HomeBook.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class BlogPostsServiceTests : BaseServiceTests
    {
        private IBlogPostsService Service => this.ServiceProvider.GetRequiredService<IBlogPostsService>();

        [Fact]
        public async Task TestAddAsyncBlogPostsShouldWorkCorrectly()
        {
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.img");
            await this.Service.AddAsync(new BlogPostInputModel
            {
                Author = "Test",
                Title = "Test test",
                Content = "Test test Test test Test test",
                Image = file,
            });
            Assert.Equal(1, this.DbContext.BlogPosts.Count());
        }

        [Fact]
        public async Task TestDeleteAsyncBlogPostShouldWorkCorrectly()
        {
            var blogPost = await this.CreateBlogPostAsync();

            await this.Service.DeleteAsync(blogPost.Id);

            var blogPostsCount = this.DbContext.BlogPosts.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedBlogPost = await this.DbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            Assert.Equal(0, blogPostsCount);
            Assert.Null(deletedBlogPost);
        }

        private async Task<BlogPost> CreateBlogPostAsync()
        {
            var blogPost = new BlogPost
            {
                Id = 100,
            };

            await this.DbContext.BlogPosts.AddAsync(blogPost);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<BlogPost>(blogPost).State = EntityState.Detached;
            return blogPost;
        }
    }
}
