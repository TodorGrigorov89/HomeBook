namespace HomeBook.Web.ViewModels.Countries
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }

        public int CitiesCount { get; set; }
    }
}
