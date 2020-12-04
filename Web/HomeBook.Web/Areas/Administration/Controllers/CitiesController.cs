namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Cities;
    using HomeBook.Services.Data.Countries;
    using HomeBook.Web.ViewModels.Cities;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CitiesController : AdministrationController
    {
        private readonly ICitiesService citiesService;
        private readonly ICountriesService countriesService;

        public CitiesController(ICitiesService citiesService, ICountriesService countriesService)
        {
            this.citiesService = citiesService;
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CitiesListViewModel
            {
                Cities = await this.citiesService.GetAllAsync<CityViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddCity()
        {
            var countries = await this.countriesService.GetAllAsync<CountrySelectListViewModel>();
            this.ViewData["Countries"] = new SelectList(countries, "Id", "Name");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityInputModel cityInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(cityInputModel);
            }

            try
            {
                await this.citiesService.AddAsync(cityInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", cityInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Cities)
            {
                return this.RedirectToAction("Index");
            }

            await this.citiesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
