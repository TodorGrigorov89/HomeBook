namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Payments;
    using HomeBook.Web.ViewModels.Payments;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class PaymentsServiceTests : BaseServiceTests
    {
        private IPaymentsService Service => this.ServiceProvider.GetRequiredService<IPaymentsService>();

        [Fact]
        public async Task TestAddAsyncPaymentShouldWorkCorrectly()
        {
            await this.Service.AddAsync(new PaymentInputModel
            {
                ElevatorSubscription = 5.20M,
                ElevatorElectricity = 4.32M,
                StairElectricity = 1.11M,
                CleaningService = 2.21M,
                RunningCosts = 1.14M,
                RepairAndRestorationFund = 3.00M,
                HouseManagerFee = 1.28M,
                ApartmentId = 1,
            });
            Assert.Equal(2, this.DbContext.Payments.Count());
        }
    }
}
