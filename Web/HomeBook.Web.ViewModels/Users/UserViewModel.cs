namespace HomeBook.Web.ViewModels.Users
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
    }
}
