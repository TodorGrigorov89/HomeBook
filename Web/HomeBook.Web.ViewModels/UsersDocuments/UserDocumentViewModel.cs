namespace HomeBook.Web.ViewModels.UsersDocuments
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class UserDocumentViewModel : IMapFrom<UserDocument>
    {
        public string ApplicationUserId { get; set; }

        public int DocumentId { get; set; }
    }
}
