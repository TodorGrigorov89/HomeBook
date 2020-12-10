namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Countries;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CountriesServiceTests : BaseServiceTests
    {
        private ICountriesService Service => this.ServiceProvider.GetRequiredService<ICountriesService>();

        [Fact]
        public async Task TestAddAsyncCountryShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new CountryInputModel { Name = "secondCountry" });
            Assert.Equal(2, this.DbContext.Countries.Count());
        }
    }
}
