namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Entrances;
    using HomeBook.Web.ViewModels.Entrances;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class EntrancesServiceTests : BaseServiceTests
    {
        private IEntrancesService Service => this.ServiceProvider.GetRequiredService<IEntrancesService>();

        [Fact]
        public async Task TestAddAsyncEntranceShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new EntranceInputModel
            {
                EntranceAddressSign = "secondEntrance",
                BuildingId = 2,
            });
            Assert.Equal(2, this.DbContext.Entrances.Count());
        }
    }
}
