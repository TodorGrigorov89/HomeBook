namespace HomeBook.Web.ViewModels.Payments
{
    public class PaymentInputModel
    {
        public decimal ElevatorSubscription { get; set; }

        public decimal ElevatorElectricity { get; set; }

        public decimal StairElectricity { get; set; }

        public decimal CleaningService { get; set; }

        public decimal RunningCosts { get; set; }

        public decimal RepairAndRestorationFund { get; set; }

        public decimal HouseManagerFee { get; set; }

        public bool? IsItPaid { get; set; }

        public decimal TotalSum => this.ElevatorSubscription + this.ElevatorElectricity +
                           this.StairElectricity + this.CleaningService + this.RunningCosts +
                           this.RepairAndRestorationFund + this.HouseManagerFee;

        public int ApartmentId { get; set; }
    }
}
