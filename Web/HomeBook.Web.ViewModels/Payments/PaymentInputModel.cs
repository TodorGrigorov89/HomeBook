namespace HomeBook.Web.ViewModels.Payments
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentInputModel
    {
        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 999.99!")]
        [Range(0.00, 999.99)]
        public decimal ElevatorSubscription { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 999.99!")]
        [Range(0.00, 999.99)]
        public decimal ElevatorElectricity { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 999.99!")]
        [Range(0.00, 999.99)]
        public decimal StairElectricity { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 999.99!")]
        [Range(0.00, 999.99)]
        public decimal CleaningService { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 999.99!")]
        [Range(0.00, 999.99)]
        public decimal RunningCosts { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 9999.99!")]
        [Range(0.00, 9999.99)]
        public decimal RepairAndRestorationFund { get; set; }

        [RegularExpression(@"^\d{1,3}\.\d{0,2}$", ErrorMessage = "Please enter a decimal point value from 0.00 to 99.99!")]
        [Range(0.00, 99.99)]
        public decimal HouseManagerFee { get; set; }

        public decimal TotalSum => this.ElevatorSubscription + this.ElevatorElectricity +
                           this.StairElectricity + this.CleaningService + this.RunningCosts +
                           this.RepairAndRestorationFund + this.HouseManagerFee;

        public int ApartmentId { get; set; }
    }
}
