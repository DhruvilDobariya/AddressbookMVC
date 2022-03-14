using Addressbook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Addressbook.Service
{
    public class DropDownList : IDropDownList
    {
        private readonly AddressBookContext _db;

        public string Message { get; set; }

        public DropDownList(AddressBookContext db)
        {
            _db = db;
        }

        public List<SelectListItem> Countries()
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
                Message = ex.Message;
                return countryList;
            }
        }

        public List<SelectListItem> States()
        {
            var stateList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Please Select State", Value = "-1", Selected = true, Disabled = true}
            };
            try
            {
                var states = _db.States.ToList();
                foreach (var state in states)
                {
                    stateList.Add(new SelectListItem() { Text = state.StateName, Value = state.StateId.ToString() });
                }
                return stateList;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return stateList;
            }
        }

        public List<SelectListItem> Cities()
        {
            var citiesList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Please Select City", Value = "-1", Selected = true, Disabled = true}
            };
            try
            {
                var cities = _db.Cities.ToList();
                foreach (var city in cities)
                {
                    citiesList.Add(new SelectListItem() { Text = city.CityName, Value = city.CityId.ToString() });
                }
                return citiesList;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return citiesList;
            }
        }

        public List<SelectListItem> ContactCategories()
        {
            var contactCategoryList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Please Select Contact Category", Value = "-1", Selected = true, Disabled = true}
            };
            try
            {
                var contactCategories = _db.ContactCategories.ToList();
                foreach (var contactCategory in contactCategories)
                {
                    contactCategoryList.Add(new SelectListItem() { Text = contactCategory.ContactCategoryName, Value = contactCategory.ContactCategoryId.ToString() });
                }
                return contactCategoryList;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return contactCategoryList;
            }
        }
    }
}
