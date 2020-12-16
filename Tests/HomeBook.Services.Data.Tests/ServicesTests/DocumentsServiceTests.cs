namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Documents;
    using HomeBook.Web.ViewModels.Documents;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DocumentsServiceTests : BaseServiceTests
    {
        private IDocumentsService Service => this.ServiceProvider.GetRequiredService<IDocumentsService>();

        [Fact]
        public async Task TestAddAsyncDocumentShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new DocumentInputModel
            {
                DocumentType = HomeBook.Data.Models.Enums.DocumentType.Complaint,
                Description = "Test Document Test Document Test Document Test Document",
            });

            Assert.Equal(2, this.DbContext.Documents.Count());
        }

        [Fact]
        public async Task TestDeleteAsyncDocumentShouldWorkCorrectly()
        {
            var document = await this.CreateDocumentAsync();

            await this.Service.DeleteAsync(document.Id);

            var documentsCount = this.DbContext.Documents.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedDocument = await this.DbContext.Documents.FirstOrDefaultAsync(x => x.Id == document.Id);
            Assert.Equal(1, documentsCount);
            Assert.Null(deletedDocument);
        }

        private async Task<Document> CreateDocumentAsync()
        {
            var document = new Document
            {
                Id = 100,
            };

            await this.DbContext.Documents.AddAsync(document);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Document>(document).State = EntityState.Detached;
            return document;
        }
    }
}
