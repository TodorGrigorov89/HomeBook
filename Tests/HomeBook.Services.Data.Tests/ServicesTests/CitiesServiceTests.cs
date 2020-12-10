namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Cities;
    using HomeBook.Web.ViewModels.Cities;
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
    }
}
