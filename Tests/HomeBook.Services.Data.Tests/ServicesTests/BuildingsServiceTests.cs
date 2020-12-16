namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Buildings;
    using HomeBook.Web.ViewModels.Buildings;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task TestDeleteAsyncBuildingShouldWorkCorrectly()
        {
            var building = await this.CreateBuildingAsync();

            await this.Service.DeleteAsync(building.Id);

            var buildingsCount = this.DbContext.Buildings.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedBuilding = await this.DbContext.Buildings.FirstOrDefaultAsync(x => x.Id == building.Id);
            Assert.Equal(1, buildingsCount);
            Assert.Null(deletedBuilding);
        }

        private async Task<Building> CreateBuildingAsync()
        {
            var building = new Building
            {
                Id = 100,
            };

            await this.DbContext.Buildings.AddAsync(building);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Building>(building).State = EntityState.Detached;
            return building;
        }
    }
}
