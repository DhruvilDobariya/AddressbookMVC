using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class CountryController : Controller
    {
        private readonly AddressBookContext _db;
        public CountryController(AddressBookContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var countries = await _db.Countries.ToListAsync();
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _db.AddAsync(country);
                    await _db.SaveChangesAsync();
                    ModelState.Clear();
                    TempData["Success"] = "Country added successfully.";
                    return View();
                }
                return View(country);
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("Violation of UNIQUE KEY constraint 'IX_Country'."))
                {
                    TempData["Error"] = "Country already exist.";
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
                    return NotFound("Country Not Found.");
                }
                var country = await _db.Countries.FindAsync(Id);
                if (country == null)
                {
                    return NotFound("Country Not Found");
                }
                return View(country);
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(country);
                    await _db.SaveChangesAsync();
                    TempData["Success"] = "Country updated successfully";
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            catch(Exception ex)
            {
                if(ex.ToString().Contains("Violation of UNIQUE KEY constraint 'IX_Country'."))
                {
                    TempData["Error"] = "Country already exist.";
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
                    return NotFound("Country Not Found.");
                }
                var country = await _db.Countries.FindAsync(Id);
                if (country == null)
                {
                    return NotFound("Country Not Found.");
                }
                _db.Remove(country);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Country deleted successfully.";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("FK_State_Country")) ;
                {
                    TempData["Error"] = "This country have few states, so if you want to delete this country then please delete these state and then you can able to delete this country.";
                }
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
