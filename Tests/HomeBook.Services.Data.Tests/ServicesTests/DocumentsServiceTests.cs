namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Documents;
    using HomeBook.Web.ViewModels.Documents;
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
    }
}
