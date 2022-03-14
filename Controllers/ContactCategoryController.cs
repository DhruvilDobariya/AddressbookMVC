using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class ContactCategoryController : Controller
    {
        private readonly IContactCategoryRepository _ContactCategoryRepository;
        private readonly ICRUDRepository<ContactCategory> _CRUDRepository;
        public ContactCategoryController(IContactCategoryRepository ContactCategoryRepository, ICRUDRepository<ContactCategory> CRUDRepository)
        {
            _ContactCategoryRepository = ContactCategoryRepository;
            _CRUDRepository = CRUDRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _CRUDRepository.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCategory contactCategory)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.InsertAsync(contactCategory))
                {
                    ModelState.Clear();
                    TempData["Success"] = "Contact category added successfully";
                    return View();
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            return View(contactCategory);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Contact Category Not Found.");
            }
            ContactCategory contactCategory = await _CRUDRepository.GetByIdAsync(Id);
            if (contactCategory == null)
            {
                return NotFound("Contact Category Not Found.");
            }
            return View(contactCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ContactCategory contactCategory)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.UpdateAsync(contactCategory))
                {
                    TempData["Success"] = "Contact category updated successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            return View(contactCategory);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Contact Category Not Found.");
            }
            if(await _CRUDRepository.DeleteAsync(Id))
            {
                TempData["Success"] = "Contact category deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _CRUDRepository.Message;
            return RedirectToAction("Index");
        } 
    }
}
