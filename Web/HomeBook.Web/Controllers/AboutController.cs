namespace HomeBook.Web.Controllers
{
    using System.Threading.Tasks;

    using HomeBook.Services.Data.Apartments;
    using HomeBook.Services.Data.Buildings;
    using HomeBook.Services.Data.Cities;
    using HomeBook.Services.Data.Users;
    using HomeBook.Web.ViewModels.About;
    using HomeBook.Web.ViewModels.Apartments;
    using HomeBook.Web.ViewModels.Buildings;
    using HomeBook.Web.ViewModels.Cities;
    using HomeBook.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;

    public class AboutController : BaseController
    {
        private readonly IApartmentsService apartmentsService;
        private readonly ICitiesService citiesService;
        private readonly IBuildingsService buildingsService;
        private readonly IUsersService usersService;

        public AboutController(IApartmentsService apartmentsService, ICitiesService citiesService, IBuildingsService buildingsService, IUsersService usersService)
        {
            this.apartmentsService = apartmentsService;
            this.citiesService = citiesService;
            this.buildingsService = buildingsService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new FactsSectionViewModel
            {
                Apartments = await this.apartmentsService.GetAllAsync<ApartmentViewModel>(),
                Cities = await this.citiesService.GetAllAsync<CityViewModel>(),
                Buildings = await this.buildingsService.GetAllAsync<BuildingViewModel>(),
                Users = await this.usersService.GetAllAsync<UserViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
