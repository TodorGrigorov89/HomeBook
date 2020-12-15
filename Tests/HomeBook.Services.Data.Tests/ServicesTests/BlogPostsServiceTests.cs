namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.BlogPosts;
    using HomeBook.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Http;
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
    }
}
