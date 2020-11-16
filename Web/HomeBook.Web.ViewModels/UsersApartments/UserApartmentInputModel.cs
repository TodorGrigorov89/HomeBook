namespace HomeBook.Web.ViewModels.UsersApartments
{
    using System.ComponentModel.DataAnnotations;

    public class UserApartmentInputModel
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public int ApartmentId { get; set; }
    }
}
