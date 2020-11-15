namespace HomeBook.Web.ViewModels.Cities
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public string Name { get; set; }

        public int StreetsCount { get; set; }
    }
}
