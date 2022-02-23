using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class ContactCategoryController : Controller
    {
        private readonly AddressBookContext _db;
        public ContactCategoryController(AddressBookContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.ContactCategories.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCategory contactCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contactCategory);
                }
                await _db.ContactCategories.AddAsync(contactCategory);
                await _db.SaveChangesAsync();
                ModelState.Clear();
                TempData["Success"] = "Contact category added successfully";
                return View();
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("Cannot insert duplicate key row in object 'dbo.ContactCategory' with unique index 'IX_ContactCategory'."))
                {
                    TempData["Error"] = "Contact category already exist.";
                }
                else
                {
                    TempData["Error"] = ex.Message;
                }
                return View();
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return NotFound("Contact Category Not Found.");
                }
                var contactCategory = await _db.ContactCategories.FindAsync(Id);
                if (contactCategory == null)
                {
                    return NotFound("Contact Category Not Found.");
                }
                return View(contactCategory);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ContactCategory contactCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contactCategory);
                }
                _db.Update(contactCategory);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Contact category updated successfully";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("Cannot insert duplicate key row in object 'dbo.ContactCategory' with unique index 'IX_ContactCategory'."))
                {
                    TempData["Error"] = "Contact category already exist.";
                }
                else
                {
                    TempData["Error"] = ex.Message;
                }
                return View();
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return NotFound("Contact Category Not Found.");
                }
                var contactCategory = await _db.ContactCategories.FindAsync(Id);
                _db.Remove(contactCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        } 
    }
}
