using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Controllers
{
    public class StateController : Controller
    {
        private readonly AddressBookContext _db;
        public StateController(AddressBookContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            try
            {
                var query = from State in _db.States
                            join Country in _db.Countries on State.CountryId equals Country.CountryId
                            select new State
                            {
                                StateId = State.StateId,
                                CountryId = Country.CountryId,
                                StateCode = State.StateCode,
                                StateName = State.StateName,
                                CreationDate = State.CreationDate,
                                Country = Country,
                            };
                return View(query);
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
            try
            {
                if(state == null)
                {
                    return View(state);
                }
                await _db.AddAsync(state);
                await _db.SaveChangesAsync();
                ModelState.Clear();
                ViewBag.Countries = GetCountryList();
                TempData["Success"] = "State added successfully";
                return View();
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint 'IX_State'."))
                {
                    TempData["Error"] = "State already exist.";
                }
                else
                {
                    TempData["Error"] = ex.Message;
                }
                ViewBag.Countries = GetCountryList();
                return View(state);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                if(Id == 0)
                {
                    return NotFound("State Not Found");
                }
                var state = await _db.States.FindAsync(Id);
                ViewBag.Countries = GetCountryList();
                return View(state);
            }  
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        //[ActionName("Update")]
        //[Route("State/Update/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(state);
                    await _db.SaveChangesAsync();
                    TempData["Success"] = "State updated successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.Countries = GetCountryList();
                return View(state);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint 'IX_State'."))
                {
                    TempData["Error"] = "State already exist.";
                }
                else
                {
                    TempData["Error"] = ex.Message;
                }
                ViewBag.Countries = GetCountryList();
                return View(state);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if(Id == 0)
                {
                    return NotFound("State Not Found");
                }
                var state = await _db.States.FindAsync(Id);
                if(state == null)
                {
                    return NotFound("State Not Found");
                }
                _db.Remove(state);
                await _db.SaveChangesAsync();
                TempData["Success"] = "State deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        private List<SelectListItem> GetCountryList()
        {
            var countryList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Please Select Country", Value = "-1", Selected = true, Disabled = true}
            };
            try
            {
                var countries = _db.Countries.ToList();
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
