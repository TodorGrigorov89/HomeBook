namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Buildings;
    using HomeBook.Web.ViewModels.Buildings;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class BuildingsServiceTests : BaseServiceTests
    {
        private IBuildingsService Service => this.ServiceProvider.GetRequiredService<IBuildingsService>();

        [Fact]
        public async Task TestAddAsyncBuildingShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new BuildingInputModel
            {
                BuildingFullAddress = "secondBuilding",
                NumberOfEntrances = 2,
                NumberOfFloors = 10,
                NumberOfApartments = 20,
                StreetId = 2,
            });
            Assert.Equal(2, this.DbContext.Buildings.Count());
        }
    }
}
