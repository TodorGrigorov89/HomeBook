namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Cities;
    using HomeBook.Services.Data.Streets;
    using HomeBook.Web.ViewModels.Cities;
    using HomeBook.Web.ViewModels.Streets;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class StreetsController : AdministrationController
    {
        private readonly IStreetsService streetsService;
        private readonly ICitiesService citiesService;

        public StreetsController(IStreetsService streetsService, ICitiesService citiesService)
        {
            this.streetsService = streetsService;
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new StreetsListViewModel
            {
                Streets = await this.streetsService.GetAllAsync<StreetViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddStreet()
        {
            var cities = await this.citiesService.GetAllAsync<CitySelectListViewModel>();
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStreet(StreetInputModel streetInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(streetInputModel);
            }

            await this.streetsService.AddAsync(streetInputModel);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStreet(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Streets)
            {
                return this.RedirectToAction("Index");
            }

            await this.streetsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
