namespace HomeBook.Web.ViewModels.Cities
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class CitySelectListViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
