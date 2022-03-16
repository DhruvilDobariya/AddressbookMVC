using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Addressbook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Addressbook.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _CityRepository;
        private readonly IDropDownList _DropDownList;
        private readonly ICRUDRepository<City> _CRUDRepository;

        public CityController(ICityRepository CityRepository, IDropDownList DropDownList, ICRUDRepository<City> CRUDRepository)
        {
            _CityRepository = CityRepository;
            _DropDownList = DropDownList;
            _CRUDRepository = CRUDRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<City> cities = _CityRepository.GetAllWithJoin();
            return View(cities);
        }

        public IActionResult Create()
        {
            ViewBag.States = _DropDownList.States();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.InsertAsync(city))
                {
                    ModelState.Clear();
                    TempData["Success"] = "City added successfully";
                    return View();
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            ViewBag.States = _DropDownList.States();
            return View(city);
        }

        public async Task<IActionResult> Update(int id)
        {
            if(id == 0)
            {
                return NotFound("City Not Found");
            }
            City city = await _CRUDRepository.GetByIdAsync(id);
            if(city == null)
            {
                TempData["Error"] = _CRUDRepository.Message;
                return RedirectToAction("Index");
            }
            ViewBag.States = _DropDownList.States();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(City city)
        {
            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.UpdateAsync(city))
                {
                    ModelState.Clear();
                    TempData["Success"] = "City updated successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            ViewBag.States = _DropDownList.States();
            return View(city);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound("City Not Found");
            }
            if(await _CRUDRepository.DeleteAsync(id))
            {
                TempData["Success"] = "City deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _CRUDRepository.Message;
            return RedirectToAction("Index");
        }
    }
}
