namespace HomeBook.Web.ViewModels.Apartments
{
    using System.Collections.Generic;

    using HomeBook.Web.ViewModels.Payments;

    public class ApartmentsListViewModel
    {
        public IEnumerable<ApartmentViewModel> Apartments { get; set; }

        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
