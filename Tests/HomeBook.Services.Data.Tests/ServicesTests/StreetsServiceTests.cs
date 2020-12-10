namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Streets;
    using HomeBook.Web.ViewModels.Streets;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class StreetsServiceTests : BaseServiceTests
    {
        private IStreetsService Service => this.ServiceProvider.GetRequiredService<IStreetsService>();

        [Fact]
        public async Task TestAddAsyncStreetShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new StreetInputModel { Name = "secondStreet", CityId = 2 });
            Assert.Equal(2, this.DbContext.Streets.Count());
        }
    }
}
