namespace HomeBook.Web.ViewModels.Documents
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class DocumentSelectListViewModel : IMapFrom<Document>
    {
        public int Id { get; set; }

        public string DocumentType { get; set; }
    }
}
