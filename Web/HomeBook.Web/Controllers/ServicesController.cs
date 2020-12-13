namespace HomeBook.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Web.ViewModels.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<UserApartment> usersApartmentsRepository;
        private readonly IDeletableEntityRepository<Payment> paymentsRepository;

        public ServicesController(UserManager<ApplicationUser> userManager, IDeletableEntityRepository<UserApartment> usersApartmentsRepository, IDeletableEntityRepository<Payment> paymentsRepository)
        {
            this.userManager = userManager;
            this.usersApartmentsRepository = usersApartmentsRepository;
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

            var allPayments = this.paymentsRepository.All().Where(x => x.ApartmentId == userApartmentsIds.FirstOrDefault());

            var userApartmentPayments = new List<decimal>();
            var paymentsDates = new List<string>();

            foreach (var apartmentId in userApartmentsIds)
            {
                    foreach (var payment in allPayments)
                    {
                        userApartmentPayments.Add(payment.TotalSum);
                        paymentsDates.Add(payment.CreatedOn.ToString());
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
