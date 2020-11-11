namespace HomeBook.Data.Models
{
    public class UserDocument
    {
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
    }
}
