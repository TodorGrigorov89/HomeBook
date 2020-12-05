namespace HomeBook.Web.ViewModels.Payments
{
    using System.Collections.Generic;

    public class PaymentsListViewModel
    {
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
