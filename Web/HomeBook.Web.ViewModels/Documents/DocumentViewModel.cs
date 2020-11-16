namespace HomeBook.Web.ViewModels.Documents
{
    using HomeBook.Data.Models;
    using HomeBook.Data.Models.Enums;
    using HomeBook.Services.Mapping;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public DocumentType DocumentType { get; set; }

        public string Description { get; set; }

        public int DocumentUsersCount { get; set; }
    }
}
