namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Apartments;
    using HomeBook.Web.ViewModels.Apartments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class ApartmentsServiceTests : BaseServiceTests
    {
        private IApartmentsService Service => this.ServiceProvider.GetRequiredService<IApartmentsService>();

        [Fact]
        public async Task TestAddAsyncApartmentShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new ApartmentInputModel
            {
                ApartmentNumber = "61",
                Floor = 8,
                NumberOfResidents = 3,
                Area = 80.25,
                EntranceId = 1,
            });
            Assert.Equal(2, this.DbContext.Apartments.Count());
        }

        [Fact]
        public async Task TestDeleteAsyncApartmentShouldWorkCorrectly()
        {
            var apartment = await this.CreateApartmentAsync();

            await this.Service.DeleteAsync(apartment.Id);

            var apartmentsCount = this.DbContext.Apartments.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedApartment = await this.DbContext.Apartments.FirstOrDefaultAsync(x => x.Id == apartment.Id);
            Assert.Equal(1, apartmentsCount);
            Assert.Null(deletedApartment);
        }

        private async Task<Apartment> CreateApartmentAsync()
        {
            var apartment = new Apartment
            {
                Id = 100,
            };

            await this.DbContext.Apartments.AddAsync(apartment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Apartment>(apartment).State = EntityState.Detached;
            return apartment;
        }
    }
}
