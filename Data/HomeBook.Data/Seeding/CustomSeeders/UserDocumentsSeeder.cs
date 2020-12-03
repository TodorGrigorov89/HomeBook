namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class UserDocumentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.UserDocuments.Any())
            {
                return;
            }

            var user = dbContext.Users.FirstOrDefault(x => x.Email == "todorgrigorov89@gmail.com");
            var document = dbContext.Documents.FirstOrDefault(x => x.Id == 1);

            var userDocument = new UserDocument
            {
                ApplicationUserId = user.Id,
                DocumentId = document.Id,
            };

            await dbContext.AddAsync(userDocument);
            await dbContext.SaveChangesAsync();
        }
    }
}
