namespace HomeBook.Web.ViewModels.UsersApartments
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class UserApartmentViewModel : IMapFrom<UserApartment>
    {
        public string ApplicationUserId { get; set; }

        public int ApartmentId { get; set; }
    }
}
