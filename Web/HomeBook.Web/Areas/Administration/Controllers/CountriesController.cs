namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Countries;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.AspNetCore.Mvc;

    public class CountriesController : AdministrationController
    {
        private readonly ICountriesService countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CountriesListViewModel
            {
                Countries = await this.countriesService.GetAllAsync<CountryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddCountry()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CountryInputModel countryInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(countryInputModel);
            }

            try
            {
                await this.countriesService.AddAsync(countryInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", countryInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Countries)
            {
                return this.RedirectToAction("Index");
            }

            await this.countriesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
