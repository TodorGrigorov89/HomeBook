namespace HomeBook.Data.Models
{
    public class UserApartment
    {
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
