namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class StreetsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Streets.Any())
            {
                return;
            }

            var street = new Street
            {
                Name = "Hadzhi Dimitar",
                CityId = 1,
            };

            await dbContext.AddAsync(street);
            await dbContext.SaveChangesAsync();
        }
    }
}
