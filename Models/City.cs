using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Addressbook.Models
{
    public partial class City
    {
        public City()
        {
            Contacts = new HashSet<Contact>();
        }

        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = null!;

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State Name")]
        public int StateId { get; set; }
        public string? Stdcode { get; set; }
        public string? PinCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual State? State { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
