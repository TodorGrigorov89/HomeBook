namespace HomeBook.Services.Data.Documents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Documents;
    using Microsoft.EntityFrameworkCore;

    public class DocumentsService : IDocumentsService
    {
        private readonly IDeletableEntityRepository<Document> documentsRepository;

        public DocumentsService(IDeletableEntityRepository<Document> documentsRepository)
        {
            this.documentsRepository = documentsRepository;
        }

        public async Task AddAsync(DocumentInputModel documentInputModel)
        {
            var document = new Document
            {
                DocumentType = documentInputModel.DocumentType,
                Description = documentInputModel.Description,
            };

            await this.documentsRepository.AddAsync(document);
            await this.documentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var documents =
                await this.documentsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return documents;
        }

        public async Task DeleteAsync(int id)
        {
            var document =
                await this.documentsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.documentsRepository.Delete(document);
            await this.documentsRepository.SaveChangesAsync();
        }
    }
}
