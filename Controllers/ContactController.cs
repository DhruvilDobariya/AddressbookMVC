using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
