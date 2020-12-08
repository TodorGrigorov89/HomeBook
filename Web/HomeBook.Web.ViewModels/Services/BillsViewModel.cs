namespace HomeBook.Web.ViewModels.Services
{
    using System.Collections.Generic;

    public class BillsViewModel
    {
        public string UserEmail { get; set; }

        public List<int> ApartmentsIds { get; set; }

        public List<decimal> Payments { get; set; }

        public List<string> Dates { get; set; }
    }
}
