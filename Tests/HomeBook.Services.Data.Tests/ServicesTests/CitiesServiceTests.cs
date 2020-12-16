namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Cities;
    using HomeBook.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CitiesServiceTests : BaseServiceTests
    {
        private ICitiesService Service => this.ServiceProvider.GetRequiredService<ICitiesService>();

        [Fact]
        public async Task TestAddAsyncCityShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new CityInputModel { Name = "secondCity", CountryId = 5 });
            Assert.Equal(2, this.DbContext.Cities.Count());
        }

        [Fact]
        public async Task TestDeleteAsyncCityShouldWorkCorrectly()
        {
            var city = await this.CreateApartmentAsync();

            await this.Service.DeleteAsync(city.Id);

            var citiesCount = this.DbContext.Cities.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedCity = await this.DbContext.Cities.FirstOrDefaultAsync(x => x.Id == city.Id);
            Assert.Equal(1, citiesCount);
            Assert.Null(deletedCity);
        }

        private async Task<City> CreateApartmentAsync()
        {
            var city = new City
            {
                Id = 100,
            };

            await this.DbContext.Cities.AddAsync(city);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<City>(city).State = EntityState.Detached;
            return city;
        }
    }
}
