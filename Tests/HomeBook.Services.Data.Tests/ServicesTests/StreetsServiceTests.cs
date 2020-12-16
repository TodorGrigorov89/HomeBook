namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Streets;
    using HomeBook.Web.ViewModels.Streets;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task TestDeleteAsyncStreetShouldWorkCorrectly()
        {
            var street = await this.CreateStreetAsync();

            await this.Service.DeleteAsync(street.Id);

            var streetsCount = this.DbContext.Streets.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedStreet = await this.DbContext.Streets.FirstOrDefaultAsync(x => x.Id == street.Id);
            Assert.Equal(1, streetsCount);
            Assert.Null(deletedStreet);
        }

        private async Task<Street> CreateStreetAsync()
        {
            var street = new Street
            {
                Id = 100,
            };

            await this.DbContext.Streets.AddAsync(street);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Street>(street).State = EntityState.Detached;
            return street;
        }
    }
}
