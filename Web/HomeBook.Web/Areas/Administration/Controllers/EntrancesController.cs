namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Buildings;
    using HomeBook.Services.Data.Entrances;
    using HomeBook.Web.ViewModels.Buildings;
    using HomeBook.Web.ViewModels.Entrances;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EntrancesController : AdministrationController
    {
        private readonly IEntrancesService entrancesService;
        private readonly IBuildingsService buildingsService;

        public EntrancesController(IEntrancesService entrancesService, IBuildingsService buildingsService)
        {
            this.entrancesService = entrancesService;
            this.buildingsService = buildingsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new EntrancesListViewModel
            {
                Entrances = await this.entrancesService.GetAllAsync<EntranceViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddEntrance()
        {
            var buildings = await this.buildingsService.GetAllAsync<BuildingsSelectListViewModel>();
            this.ViewData["Buildings"] = new SelectList(buildings, "Id", "BuildingFullAddress");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEntrance(EntranceInputModel entranceInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(entranceInputModel);
            }

            try
            {
                await this.entrancesService.AddAsync(entranceInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", entranceInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEntrance(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Entrances)
            {
                return this.RedirectToAction("Index");
            }

            await this.entrancesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
