namespace HomeBook.Services.Data.Payments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HomeBook.Web.ViewModels.Payments;

    public interface IPaymentsService
    {
        Task AddAsync(PaymentInputModel paymentInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
