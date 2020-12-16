namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Payments;
    using HomeBook.Web.ViewModels.Payments;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task TestDeleteAsyncPaymentShouldWorkCorrectly()
        {
            var payment = await this.CreatePaymentAsync();

            await this.Service.DeleteAsync(payment.Id);

            var paymentsCount = this.DbContext.Payments.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedPayment = await this.DbContext.Payments.FirstOrDefaultAsync(x => x.Id == payment.Id);
            Assert.Equal(1, paymentsCount);
            Assert.Null(deletedPayment);
        }

        private async Task<Payment> CreatePaymentAsync()
        {
            var payment = new Payment
            {
                Id = 100,
            };

            await this.DbContext.Payments.AddAsync(payment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Payment>(payment).State = EntityState.Detached;
            return payment;
        }
    }
}
