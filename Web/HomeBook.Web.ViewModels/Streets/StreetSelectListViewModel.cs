namespace HomeBook.Web.ViewModels.Streets
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class StreetSelectListViewModel : IMapFrom<Street>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
