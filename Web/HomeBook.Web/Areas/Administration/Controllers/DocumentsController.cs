namespace HomeBook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Services.Data.Documents;
    using HomeBook.Services.Data.UsersDocuments;
    using HomeBook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class DocumentsController : AdministrationController
    {
        private readonly IDocumentsService documentsService;

        public DocumentsController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DocumentsListViewModel
            {
                Documents = await this.documentsService.GetAllAsync<DocumentViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddDocument()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(DocumentInputModel documentInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(documentInputModel);
            }

            try
            {
                await this.documentsService.AddAsync(documentInputModel);
            }
            catch (Exception)
            {
                return this.View("DuplicateValue", documentInputModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            if (id <= GlobalConstants.SeededDataCounts.Documents)
            {
                return this.RedirectToAction("Index");
            }

            await this.documentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
