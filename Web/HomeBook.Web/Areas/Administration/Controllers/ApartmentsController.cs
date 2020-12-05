namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Apartments;
    using HomeBook.Services.Data.Entrances;
    using HomeBook.Services.Data.Payments;
    using HomeBook.Web.ViewModels.Apartments;
    using HomeBook.Web.ViewModels.Entrances;
    using HomeBook.Web.ViewModels.Payments;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ApartmentsController : AdministrationController
    {
        private readonly IApartmentsService apartmentsService;
        private readonly IEntrancesService entrancesService;
        private readonly IPaymentsService paymentsService;

        public ApartmentsController(IApartmentsService apartmentsService, IEntrancesService entrancesService, IPaymentsService paymentsService)
        {
            this.apartmentsService = apartmentsService;
            this.entrancesService = entrancesService;
            this.paymentsService = paymentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ApartmentsListViewModel
            {
                Apartments = await this.apartmentsService.GetAllAsync<ApartmentViewModel>(),
                Payments = await this.paymentsService.GetAllAsync<PaymentViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddApartment()
        {
            var entrances = await this.entrancesService.GetAllAsync<EntrancesSelectListViewModel>();
            this.ViewData["Entrances"] = new SelectList(entrances, "Id", "EntranceAddressSign");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(ApartmentInputModel apartmentInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(apartmentInputModel);
            }

            try
            {
                await this.apartmentsService.AddAsync(apartmentInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", apartmentInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Apartments)
            {
                return this.RedirectToAction("Index");
            }

            await this.apartmentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
