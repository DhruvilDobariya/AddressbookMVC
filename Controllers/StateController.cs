using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Addressbook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateRepository _Repository; // Here we always use interface
        private readonly ICRUDRepository<State> _CRUDRepository;
        private readonly ICountryRepository _CountryRepository;
        private readonly IDropDownList _DropDownList;

        public StateController(IStateRepository Repository, ICRUDRepository<State> CRUDRepository, ICountryRepository CountryRepository, IDropDownList DropDownList)
        {
            _Repository = Repository;
            _CRUDRepository = CRUDRepository;
            _CountryRepository = CountryRepository;
            _DropDownList = DropDownList;
        }

        [Route("~/State/List")]
        public IActionResult Index()
        {
            var states = _Repository.GetAllWithJoin();
            return View(states);
        }

        public IActionResult Create()
        {
            ViewBag.Countries = _DropDownList.Countries();
            return View();
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
            ViewBag.Countries = _DropDownList.Countries();
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
            ViewBag.Countries = _DropDownList.Countries();
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
            ViewBag.Countries = _DropDownList.Countries();
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
    }
}
