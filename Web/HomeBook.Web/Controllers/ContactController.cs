namespace HomeBook.Web.Controllers
{
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Messaging;
    using HomeBook.Web.ViewModels.ContactForm;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly IRepository<ContactForm> contactsRepository;

        private readonly IEmailSender emailSender;

        public ContactController(IRepository<ContactForm> contactsRepository, IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var contactFormEntry = new ContactForm
            {
                Name = model.Name,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content,
            };
            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                model.Email,
                model.Name,
                GlobalConstants.AccountsSeeding.AdminEmail,
                model.Title,
                model.Content);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
