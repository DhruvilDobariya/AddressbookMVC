using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Addressbook.Service;
using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _Repository;
        private readonly ICRUDRepository<Contact> _CRUDRepository;
        private readonly IDropDownList _DropDownList;

        public ContactController(IContactRepository Repository, ICRUDRepository<Contact> CRUDRepository, IDropDownList DropDownList)
        {
            _Repository = Repository;
            _CRUDRepository = CRUDRepository;
            _DropDownList = DropDownList;
        }

        public IActionResult Index()
        {
            return View(_Repository.GetAllWithJoin());
        }

        public IActionResult Create()
        {
            GetDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.InsertAsync(contact))
                {
                    ModelState.Clear();
                    TempData["Success"] = "Contact addedd successfully";
                    GetDropDowns();
                    return View();
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            GetDropDowns();
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            if(id == 0)
            {
                return NotFound("Contact Not Found");
            }
            Contact contact = await _CRUDRepository.GetByIdAsync(id);
            if(contact == null)
            {
                TempData["Error"] = _CRUDRepository.Message;
                return RedirectToAction("Index");
            }
            GetDropDowns();
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.UpdateAsync(contact))
                {
                    TempData["Success"] = "Contact updated successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            GetDropDowns();
            return View(contact);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound("Contact Not Found");
            }
            if(await _CRUDRepository.DeleteAsync(id))
            {
                TempData["Success"] = "Contact deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _CRUDRepository.Message;
            return RedirectToAction("Index");
        }

        private void GetDropDowns()
        {
            ViewBag.ContactCategories = _DropDownList.ContactCategories();
            ViewBag.Cities = _DropDownList.Cities();
            ViewBag.States = _DropDownList.States();
            ViewBag.Countries = _DropDownList.Countries();
        }
    }
}
