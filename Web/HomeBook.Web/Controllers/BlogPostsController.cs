namespace HomeBook.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogPostsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
