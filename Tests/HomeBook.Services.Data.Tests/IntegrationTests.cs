namespace HomeBook.Services.Data.Tests
{
    using System.Net;
    using System.Threading.Tasks;

    using HomeBook.Web;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class IntegrationTests
    {
        [Fact]
        public async Task IndexPageShouldReturn200OK()
        {
            var server = new WebApplicationFactory<Startup>();
            var client = server.CreateClient();
            var response = await client.GetAsync("Home/Index");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
