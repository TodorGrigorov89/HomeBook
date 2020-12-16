namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Countries;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task TestDeleteAsyncCountryShouldWorkCorrectly()
        {
            var country = await this.CreateCountryAsync();

            await this.Service.DeleteAsync(country.Id);

            var countriesCount = this.DbContext.Countries.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedCountry = await this.DbContext.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);
            Assert.Equal(1, countriesCount);
            Assert.Null(deletedCountry);
        }

        private async Task<Country> CreateCountryAsync()
        {
            var country = new Country
            {
                Id = 100,
            };

            await this.DbContext.Countries.AddAsync(country);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Country>(country).State = EntityState.Detached;
            return country;
        }
    }
}
