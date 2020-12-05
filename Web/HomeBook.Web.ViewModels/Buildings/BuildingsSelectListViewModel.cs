namespace HomeBook.Web.ViewModels.Buildings
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class BuildingsSelectListViewModel : IMapFrom<Building>
    {
        public int Id { get; set; }

        public string BuildingFullAddress { get; set; }
    }
}
