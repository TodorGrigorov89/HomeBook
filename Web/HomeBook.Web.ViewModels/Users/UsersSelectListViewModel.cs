namespace HomeBook.Web.ViewModels.Users
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class UsersSelectListViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}
