namespace HomeBook.Web.ViewModels.Apartments
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class ApartmentViewModel : IMapFrom<Apartment>
    {
        public string ApartmentNumber { get; set; }

        public int Floor { get; set; }

        public int NumberOfResidents { get; set; }

        public decimal Area { get; set; }

        public int ApartmentUsersCount { get; set; }

        public int PaymentsCount { get; set; }
    }
}
