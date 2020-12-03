namespace HomeBook.Web.ViewModels.Countries
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class CountrySelectListViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
