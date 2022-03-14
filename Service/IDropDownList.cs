using Microsoft.AspNetCore.Mvc.Rendering;

namespace Addressbook.Service
{
    public interface IDropDownList
    {
        string Message { get; set; }
        List<SelectListItem> Countries();
        List<SelectListItem> States();
        List<SelectListItem> Cities();
        List<SelectListItem> ContactCategories();
    }
}
