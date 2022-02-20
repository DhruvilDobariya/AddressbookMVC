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
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var countries = await _db.Countries.ToListAsync();
                var countryList = new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Please Select Country", Value = "-1", Selected = true, Disabled = true}
                };
                foreach (var country in countries)
                {
                    countryList.Add(new SelectListItem() { Text = country.CountryName, Value = country.CountryId.ToString() });
                }

                ViewBag.Countries = countryList;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }
    }
}
