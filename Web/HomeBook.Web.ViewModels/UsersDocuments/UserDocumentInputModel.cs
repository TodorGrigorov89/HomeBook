namespace HomeBook.Web.ViewModels.UsersDocuments
{
    using System.ComponentModel.DataAnnotations;

    public class UserDocumentInputModel
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public int DocumentId { get; set; }
    }
}
