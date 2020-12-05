namespace HomeBook.Web.ViewModels.Apartments
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class ApartmentsSelectListViewModel : IMapFrom<Apartment>
    {
        public int Id { get; set; }

        public string ApartmentNumber { get; set; }
    }
}
