using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Addressbook.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Contacts = new HashSet<Contact>();
        }

        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; } = null!;

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Select Country Name")]
        public int CountryId { get; set; }

        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please Enter State Code")]
        public string? StateCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
