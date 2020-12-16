namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Entrances;
    using HomeBook.Web.ViewModels.Entrances;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task TestDeleteAsyncEntranceShouldWorkCorrectly()
        {
            var entrance = await this.CreateEntranceAsync();

            await this.Service.DeleteAsync(entrance.Id);

            var entrancesCount = this.DbContext.Entrances.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedEntrance = await this.DbContext.Entrances.FirstOrDefaultAsync(x => x.Id == entrance.Id);
            Assert.Equal(1, entrancesCount);
            Assert.Null(deletedEntrance);
        }

        private async Task<Entrance> CreateEntranceAsync()
        {
            var entrance = new Entrance
            {
                Id = 100,
            };

            await this.DbContext.Entrances.AddAsync(entrance);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Entrance>(entrance).State = EntityState.Detached;
            return entrance;
        }
    }
}
