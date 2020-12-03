namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Models;

    public class PaymentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Payments.Any())
            {
                return;
            }

            var payment = new Payment
            {
                ElevatorSubscription = 4.68M,
                ElevatorElectricity = 3.12M,
                StairElectricity = 0.32M,
                CleaningService = 2.72M,
                RunningCosts = 0.88M,
                RepairAndRestorationFund = 3.22M,
                HouseManagerFee = 3.58M,
                IsItPaid = null,
                TotalSum = 18.52M,
                ApartmentId = 30,
            };

            await dbContext.AddAsync(payment);
            await dbContext.SaveChangesAsync();
        }
    }
}
