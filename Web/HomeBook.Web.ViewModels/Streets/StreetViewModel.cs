namespace HomeBook.Web.ViewModels.Streets
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class StreetViewModel : IMapFrom<Street>
    {
        public string Name { get; set; }

        public int BuildingsCount { get; set; }
    }
}
