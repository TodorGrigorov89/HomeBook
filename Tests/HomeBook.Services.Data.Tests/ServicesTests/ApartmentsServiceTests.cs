namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Apartments;
    using HomeBook.Web.ViewModels.Apartments;
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
    }
}
