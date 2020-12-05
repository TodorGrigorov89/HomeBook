namespace HomeBook.Web.ViewModels.Payments
{
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class PaymentViewModel : IMapFrom<Payment>
    {
        public int Id { get; set; }

        public decimal ElevatorSubscription { get; set; }

        public decimal ElevatorElectricity { get; set; }

        public decimal StairElectricity { get; set; }

        public decimal CleaningService { get; set; }

        public decimal RunningCosts { get; set; }

        public decimal RepairAndRestorationFund { get; set; }

        public decimal HouseManagerFee { get; set; }

        public bool? IsItPaid { get; set; }

        public decimal TotalSum { get; set; }

        public int ApartmentId { get; set; }
    }
}
