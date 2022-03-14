using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _Repository;
        private readonly ICRUDRepository<Country> _CRUDRepository;
        public CountryController(ICountryRepository Repository, ICRUDRepository<Country> CRUDRepository)
        {
            _Repository = Repository;
            _CRUDRepository = CRUDRepository;
        }

        //[Route("[controller]/List")]
        public async Task<IActionResult> Index()
        {
            var countries = await _CRUDRepository.GetAllAsync();
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
            if (ModelState.IsValid)
            {
                bool flag = await _CRUDRepository.InsertAsync(country);
                if (flag)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Country added successfully.";
                    return View();
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            return View(country);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Country Not Found.");
            }
            var country = await _CRUDRepository.GetByIdAsync(Id);
            if (country == null)
            {
                return NotFound("Country Not Found");
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Country country)
        {
            if (ModelState.IsValid)
            {
                bool flag = await _CRUDRepository.UpdateAsync(country);
                if (flag)
                {
                    TempData["Success"] = "Country updated successfully";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = _CRUDRepository.Message;
            }
            return View(country);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Country Not Found.");
            }
            bool flag = await _CRUDRepository.DeleteAsync(Id);
            if (flag)
            {
                TempData["Success"] = "Country deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _CRUDRepository.Message;
            return RedirectToAction("Index");
        }
    }
}
