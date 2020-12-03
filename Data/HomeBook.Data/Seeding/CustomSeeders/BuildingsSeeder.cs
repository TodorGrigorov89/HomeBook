namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class BuildingsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Buildings.Any())
            {
                return;
            }

            var building = new Building
            {
                BuildingFullAddress = "Hadzhi Dimitar 2, 4, 6",
                NumberOfEntrances = 3,
                NumberOfFloors = 8,
                NumberOfApartments = 96,
                StreetId = 1,
            };

            await dbContext.AddAsync(building);
            await dbContext.SaveChangesAsync();
        }
    }
}
