using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Addressbook.Models
{
    [Index(nameof(CityName), IsUnique = true)]
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

        [ForeignKey("State")]
        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State Name")]
        public int StateId { get; set; }

        [Display(Name = "STD Code")]
        public string? Stdcode { get; set; }

        [Display(Name = "Pin Code")]
        public string? PinCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual State? State { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
