namespace HomeBook.Data.Models
{
    using HomeBook.Data.Common.Models;

    public class Payment : BaseDeletableModel<int>
    {
        public decimal ElevatorSubscription { get; set; }

        public decimal ElevatorElectricity { get; set; }

        public decimal StairElectricity { get; set; }

        public decimal CleaningService { get; set; }

        public decimal RunningCosts { get; set; }

        public decimal RepairAndRestorationFund { get; set; }

        public decimal HouseManagerFee { get; set; }

        public decimal? PastUnpaidBill { get; set; }

        public bool? IsItPaid { get; set; }

        public decimal TotalSum { get; set; }

        public int ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
    }
}
