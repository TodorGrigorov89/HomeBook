namespace HomeBook.Web.ViewModels.Entrances
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class EntrancesSelectListViewModel : IMapFrom<Entrance>
    {
        public int Id { get; set; }

        public string EntranceAddressSign { get; set; }
    }
}
