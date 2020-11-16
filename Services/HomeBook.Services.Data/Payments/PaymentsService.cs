namespace HomeBook.Services.Data.Payments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Payments;
    using Microsoft.EntityFrameworkCore;

    public class PaymentsService : IPaymentsService
    {
        private readonly IDeletableEntityRepository<Payment> paymentsRepository;

        public PaymentsService(IDeletableEntityRepository<Payment> paymentsRepository)
        {
            this.paymentsRepository = paymentsRepository;
        }

        public async Task AddAsync(PaymentInputModel paymentInputModel)
        {
            var payment = new Payment
            {
                ElevatorSubscription = paymentInputModel.ElevatorSubscription,
                ElevatorElectricity = paymentInputModel.ElevatorElectricity,
                StairElectricity = paymentInputModel.StairElectricity,
                CleaningService = paymentInputModel.CleaningService,
                RunningCosts = paymentInputModel.RunningCosts,
                RepairAndRestorationFund = paymentInputModel.RepairAndRestorationFund,
                HouseManagerFee = paymentInputModel.HouseManagerFee,
                IsItPaid = paymentInputModel?.IsItPaid,
                ApartmentId = paymentInputModel.ApartmentId,
            };

            bool doesPaymentExist = await this.paymentsRepository.All().AnyAsync(x => x.Id == payment.Id);

            if (doesPaymentExist)
            {
                throw new ArgumentException(string.Format(GlobalConstants.ErrorMessages.PaymentExists, payment.Id));
            }

            await this.paymentsRepository.AddAsync(payment);
            await this.paymentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var payments =
                await this.paymentsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return payments;
        }

        public async Task DeleteAsync(int id)
        {
            var payment =
                await this.paymentsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.paymentsRepository.Delete(payment);
            await this.paymentsRepository.SaveChangesAsync();
        }
    }
}
