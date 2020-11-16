namespace HomeBook.Services.Data.UsersDocuments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.UsersDocuments;
    using Microsoft.EntityFrameworkCore;

    public class UsersDocumentsService : IUsersDocumentsService
    {
        private readonly IDeletableEntityRepository<UserDocument> usersDocumentsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Document> documentsRepository;

        public UsersDocumentsService(
            IDeletableEntityRepository<UserDocument> usersDocumentsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Document> documentsRepository)
        {
            this.usersDocumentsRepository = usersDocumentsRepository;
            this.usersRepository = usersRepository;
            this.documentsRepository = documentsRepository;
        }

        public async Task AddAsync(UserDocumentInputModel userDocumentInputModel)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userDocumentInputModel.ApplicationUserId);

            if (user == null)
            {
                throw new NullReferenceException(
                    string.Format(GlobalConstants.ErrorMessages.UserNotFound, user.Id));
            }

            var document = await this.documentsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userDocumentInputModel.DocumentId);

            if (document == null)
            {
                throw new NullReferenceException(
                    string.Format(GlobalConstants.ErrorMessages.DocumentNotFound, document.Id));
            }

            var userDocument = new UserDocument
            {
                ApplicationUserId = userDocumentInputModel.ApplicationUserId,
                DocumentId = userDocumentInputModel.DocumentId,
            };

            bool doesUserDocumentExist = await this.usersDocumentsRepository
                .All()
                .AnyAsync(x => x.ApplicationUserId == userDocument.ApplicationUserId &&
                          x.DocumentId == userDocument.DocumentId);

            if (doesUserDocumentExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.UserDocumentExists, userDocument.ApplicationUserId, userDocument.DocumentId));
            }

            await this.usersDocumentsRepository.AddAsync(userDocument);
            await this.usersDocumentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var userDocuments =
                await this.usersDocumentsRepository
                .All()
                .OrderBy(x => x.ApplicationUserId)
                .To<T>().ToListAsync();

            return userDocuments;
        }
    }
}
