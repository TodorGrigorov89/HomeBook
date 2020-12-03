namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class DocumentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Documents.Any())
            {
                return;
            }

            var document = new Document
            {
                DocumentType = Models.Enums.DocumentType.Complaint,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Amet venenatis urna cursus eget nunc scelerisque viverra mauris. Elementum facilisis leo vel fringilla. Id diam vel quam elementum pulvinar." +
                " Rhoncus aenean vel elit scelerisque mauris pellentesque pulvinar pellentesque.",
            };

            await dbContext.AddAsync(document);
            await dbContext.SaveChangesAsync();
        }
    }
}
