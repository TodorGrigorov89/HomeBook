namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new City[]
                {
                    new City
                    {
                        Name = "Varna",
                        CountryId = 1,
                    },
                    new City
                    {
                        Name = "Sofia",
                        CountryId = 1,
                    },
                    new City
                    {
                        Name = "Plovdiv",
                        CountryId = 1,
                    },
                };

            foreach (var city in cities)
            {
                await dbContext.AddAsync(city);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
