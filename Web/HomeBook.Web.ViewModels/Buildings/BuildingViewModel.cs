namespace HomeBook.Web.ViewModels.Buildings
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class BuildingViewModel : IMapFrom<Building>
    {
        public int Id { get; set; }

        public string BuildingFullAddress { get; set; }

        public int NumberOfEntrances { get; set; }

        public int NumberOfFloors { get; set; }

        public int NumberOfApartments { get; set; }

        public int EntrancesCount { get; set; }
    }
}
