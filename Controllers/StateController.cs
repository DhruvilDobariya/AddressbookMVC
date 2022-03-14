using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class StateController : Controller
    {
        private readonly AddressBookContext _db;
        private readonly IStateRepository _Repository; // Here we always use interface
        private readonly ICRUDRepository<State> _CRUDRepository;
        private readonly ICountryRepository _CountryRepository;

        public StateController(IStateRepository Repository, ICRUDRepository<State> CRUDRepository, ICountryRepository CountryRepository)
        {
            _Repository = Repository;
            _CRUDRepository = CRUDRepository;
            _CountryRepository = CountryRepository;
        }

        [Route("~/State/List")]
        public IActionResult Index()
        {
            try
            {
                var states = _Repository.GetAllWithJoin();
                return View(states);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.Countries = GetCountryList();
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.Countries = GetCountryList();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (state == null)
            {
                return View(state);
            }
            if(await _CRUDRepository.InsertAsync(state))
            {
                TempData["Success"] = "State added successfully";
                ModelState.Clear();
                return View();
            }
            TempData["Error"] = _CRUDRepository.Message;
            ViewBag.Countries = GetCountryList();
            return View(state);
        }

        public async Task<IActionResult> Update(int Id)
        {

            if (Id == 0)
            {
                return NotFound("State Not Found");
            }
            State state = await _CRUDRepository.GetByIdAsync(Id);
            if(state == null)
            {
                TempData["Error"] = _CRUDRepository.Message;
                return RedirectToAction("Index");
            }
            ViewBag.Countries = GetCountryList();
            return View(state);
        }

        //[ActionName("Update")]
        //[Route("State/Update/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(State state)
        {

            if (ModelState.IsValid)
            {
                if(await _CRUDRepository.UpdateAsync(state))
                {
                    TempData["Success"] = "State updated successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = _CRUDRepository.Message;
            ViewBag.Countries = GetCountryList();
            return View(state);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound("State Not Found");
            }
            if(await _CRUDRepository.DeleteAsync(Id))
            {
                TempData["Success"] = "State deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = _CRUDRepository.Message;
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetCountryList()
        {
            var countryList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Please Select Country", Value = "-1", Selected = true, Disabled = true}
            };
            try
            {
                var countries = _CountryRepository.GetAll();
                foreach (var country in countries)
                {
                    countryList.Add(new SelectListItem() { Text = country.CountryName, Value = country.CountryId.ToString() });
                }
                return countryList;
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return countryList;
            }
        }
    }
}
