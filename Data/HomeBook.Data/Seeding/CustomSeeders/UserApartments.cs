namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class UserApartments : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.UserApartments.Any())
            {
                return;
            }

            var user = dbContext.Users.FirstOrDefault(x => x.Email == "todorgrigorov89@gmail.com");
            var apartment = dbContext.Apartments.FirstOrDefault(x => x.ApartmentNumber == "62");

            var userAparment = new UserApartment
            {
                ApplicationUserId = user.Id,
                ApartmentId = apartment.Id,
            };

            await dbContext.AddAsync(userAparment);
            await dbContext.SaveChangesAsync();
        }
    }
}
