namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Apartments;
    using HomeBook.Services.Data.Payments;
    using HomeBook.Web.ViewModels.Apartments;
    using HomeBook.Web.ViewModels.Payments;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PaymentsController : AdministrationController
    {
        private readonly IPaymentsService paymentsService;
        private readonly IApartmentsService apartmentsService;

        public PaymentsController(IPaymentsService paymentsService, IApartmentsService apartmentsService)
        {
            this.paymentsService = paymentsService;
            this.apartmentsService = apartmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new PaymentsListViewModel
            {
                Payments = await this.paymentsService.GetAllAsync<PaymentViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddPayment()
        {
            var apartments = await this.apartmentsService.GetAllAsync<ApartmentsSelectListViewModel>();
            this.ViewData["Apartments"] = new SelectList(apartments, "Id", "ApartmentNumber");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentInputModel paymentInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(paymentInputModel);
            }

            try
            {
                await this.paymentsService.AddAsync(paymentInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", paymentInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Payments)
            {
                return this.RedirectToAction("Index");
            }

            await this.paymentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
