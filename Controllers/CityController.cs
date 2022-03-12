using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Addressbook.Controllers
{
    public class CityController : Controller
    {
        private readonly AddressBookContext _db;
        public CityController(AddressBookContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IQueryable<City> cities = from City in _db.Cities
                     join State in _db.States on City.StateId equals State.StateId
                     select new City
                     {
                         CityId = City.CityId,
                         CityName = City.CityName,
                         StateId = City.StateId,
                         PinCode = City.PinCode,
                         Stdcode = City.Stdcode,
                         State = City.State,
                         CreationDate = City.CreationDate
                     };
            return View(cities);
        }

        public IActionResult Create()
        {
            ViewBag.States = GetState();
            return View();
        }
        public List<SelectListItem> GetState()
        {
            List<SelectListItem> states = new List<SelectListItem>();
            try
            {
                var query = from State in _db.States
                            join Country in _db.Countries on State.CountryId equals Country.CountryId
                            orderby State.CountryId
                            select new State
                            {
                                StateId = State.StateId,
                                StateName = State.StateName,
                                Country = State.Country
                            };
                int temp = 0;
                foreach(var state in query)
                {
                    temp = state.CountryId;
                    SelectListGroup group = new SelectListGroup();
                    if (temp == 0 && temp != state.CountryId)
                    {
                        group.Name = state.Country.CountryName;
                        states.Add(new SelectListItem() { Text = state.StateName, Value = state.StateId.ToString(), Group = group});
                    }
                    else
                    {
                        states.Add(new SelectListItem() { Text = state.StateName, Value = state.StateId.ToString(), Group = group });
                    }
                }
                return states;
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return states;
            }
        }
    }
}
