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
        public CityController(ICityRepository CityRepository, IDropDownList DropDownList)
        {
            _CityRepository = CityRepository;
            _DropDownList = DropDownList;
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
    }
}
