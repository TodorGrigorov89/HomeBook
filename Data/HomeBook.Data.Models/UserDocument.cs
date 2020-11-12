namespace HomeBook.Data.Models
{
    using System;

    using HomeBook.Data.Common.Models;

    public class UserDocument : IDeletableEntity
    {
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
