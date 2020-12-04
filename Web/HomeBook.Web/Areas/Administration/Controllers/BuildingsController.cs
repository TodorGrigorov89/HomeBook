namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Buildings;
    using HomeBook.Services.Data.Streets;
    using HomeBook.Web.ViewModels.Buildings;
    using HomeBook.Web.ViewModels.Streets;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class BuildingsController : AdministrationController
    {
        private readonly IBuildingsService buildingsService;
        private readonly IStreetsService streetsService;

        public BuildingsController(IBuildingsService buildingsService, IStreetsService streetsService)
        {
            this.buildingsService = buildingsService;
            this.streetsService = streetsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BuildingsListViewModel
            {
                Buildings = await this.buildingsService.GetAllAsync<BuildingViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddBuilding()
        {
            var streets = await this.streetsService.GetAllAsync<StreetSelectListViewModel>();
            this.ViewData["Streets"] = new SelectList(streets, "Id", "Name");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingInputModel buildingInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(buildingInputModel);
            }

            try
            {
                await this.buildingsService.AddAsync(buildingInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", buildingInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Buildings)
            {
                return this.RedirectToAction("Index");
            }

            await this.buildingsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
