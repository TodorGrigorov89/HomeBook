namespace HomeBook.Web.ViewModels.About
{
    using System.Collections.Generic;

    using HomeBook.Web.ViewModels.Apartments;
    using HomeBook.Web.ViewModels.Buildings;
    using HomeBook.Web.ViewModels.Cities;
    using HomeBook.Web.ViewModels.Users;

    public class FactsSectionViewModel
    {
        public IEnumerable<ApartmentViewModel> Apartments { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }

        public IEnumerable<BuildingViewModel> Buildings { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
