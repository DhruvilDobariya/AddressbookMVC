using Addressbook.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _Repository;

        public ContactController(IContactRepository Repository)
        {
            _Repository = Repository;
        }

        public IActionResult Index()
        {
            return View(_Repository.GetAllWithJoin());
        }
    }
}
