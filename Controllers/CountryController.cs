using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    public class CountryController : Controller
    {
        private readonly AddressBookContext _db;
        public CountryController(AddressBookContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var countries = _db.Countries.ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(country);
                    _db.SaveChanges();
                    ModelState.Clear();
                    return View();
                }
                return View(country);
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("Violation of UNIQUE KEY constraint 'IX_Country'."))
                {
                    ViewBag.ErrorMassege = "Country already exist.";
                }
                else
                {
                    ViewBag.ErrorMassege = ex.Message;
                }
                return View();
            }
        }

        public IActionResult Update(int Id)
        {
            if(Id == 0)
            {
                return NotFound("Country Not Found.");
            }
            var country = _db.Countries.Find(Id);
            if(country == null)
            {
                return NotFound("Country Not Found");
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Update(country);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return NotFound("Country Not Found.");
                }
                var country = _db.Countries.Find(Id);
                if (country == null)
                {
                    return NotFound("Country Not Found.");
                }
                _db.Remove(country);
                _db.SaveChanges();
                ViewBag.Massege = "Country deleted successfully.";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint 'FK_State_Country'."))
                {
                    ViewBag.ErrorMassege = "This country have few states, so if you want to delete this country then please delete these state and then you can able to delete this country.";
                }
                ViewBag.ErrorMassege = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
