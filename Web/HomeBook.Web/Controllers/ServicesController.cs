namespace HomeBook.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Data.Apartments;
    using HomeBook.Services.Data.Payments;
    using HomeBook.Services.Data.Users;
    using HomeBook.Services.Data.UsersApartments;
    using HomeBook.Web.ViewModels.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<UserApartment> usersApartmentsRepository;
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IDeletableEntityRepository<Payment> paymentsRepository;
        private readonly IApartmentsService apartmentsService;
        private readonly IUsersApartmentsService usersApartmentsService;
        private readonly IUsersService usersService;
        private readonly IPaymentsService paymentsService;

        public ServicesController(IApartmentsService apartmentsService, IUsersService usersService, IPaymentsService paymentsService, IUsersApartmentsService usersApartmentsService, UserManager<ApplicationUser> userManager, IDeletableEntityRepository<UserApartment> usersApartmentsRepository, IDeletableEntityRepository<Apartment> apartmentsRepository, IDeletableEntityRepository<Payment> paymentsRepository)
        {
            this.apartmentsService = apartmentsService;
            this.usersService = usersService;
            this.paymentsService = paymentsService;
            this.usersApartmentsService = usersApartmentsService;
            this.userManager = userManager;
            this.usersApartmentsRepository = usersApartmentsRepository;
            this.apartmentsRepository = apartmentsRepository;
            this.paymentsRepository = paymentsRepository;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Bills()
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);

            if (userId == null)
            {
                return this.RedirectToAction("Index");
            }

            var userEmail = this.userManager.FindByIdAsync(userId).Result.ToString();

            var allApartments = this.usersApartmentsRepository.All().Where(x => x.ApplicationUserId == userId).ToList();

            var userApartmentsIds = new List<int>();

            foreach (var apartment in allApartments)
            {
                userApartmentsIds.Add(apartment.ApartmentId);
            }

            var allPayments = this.paymentsRepository.All().ToList();

            var userApartmentPayments = new List<decimal>();
            var paymentsDates = new List<string>();

            foreach (var apartmentId in userApartmentsIds)
            {
                if (allPayments.Any(x => x.ApartmentId == apartmentId))
                {
                    foreach (var payment in allPayments)
                    {
                        userApartmentPayments.Add(payment.TotalSum);
                        paymentsDates.Add(payment.CreatedOn.ToString());
                    }
                }
            }

            var viewModel = new BillsViewModel
            {
                UserEmail = userEmail,
                ApartmentsIds = userApartmentsIds,
                Payments = userApartmentPayments,
                Dates = paymentsDates,
            };

            return this.View(viewModel);
        }
    }
}
