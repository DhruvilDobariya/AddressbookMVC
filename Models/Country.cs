using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Addressbook.Models
{
    public partial class Country
    {
        public Country()
        {
            Contacts = new HashSet<Contact>();
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Enter Country Name")]
        public string? CountryName { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please Enter Country Code")]
        public string CountryCode { get; set; } = null!;
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
