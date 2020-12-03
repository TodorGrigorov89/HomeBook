namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class EntrancesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Entrances.Any())
            {
                return;
            }

            var entrance = new Entrance
            {
                EntranceAddressSign = "2",
                BuildingId = 1,
            };

            await dbContext.AddAsync(entrance);
            await dbContext.SaveChangesAsync();
        }
    }
}
