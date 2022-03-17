using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Addressbook.Models
{
    /*
     * If we want to give unique key then we give like this : 
     * [Index(nameof(ContactName), IsUnique = true)]
    */
    public partial class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "Please Enter Contact Name")]
        public string ContactName { get; set; } = null!;

        [ForeignKey("ContactCategory")]
        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Select Contact Category")]
        public int ContactCategoryId { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State")]
        [Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }

        [ForeignKey("Country")]
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please Enter Contact No")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; } = null!;

        [Display(Name = "Whtasapp No")]
        [DataType(DataType.PhoneNumber)]
        public string? WhatsAppNo { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Display(Name = "Blood Group")]
        public string? BloodGroup { get; set; }

        [Display(Name = "Facebook Id")]
        [DataType(DataType.Url)]
        public string? FacebookId { get; set; }

        [Display(Name = "Linkedin Id")]
        [DataType(DataType.Url)]
        public string? LinkedInId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual City? City { get; set; }
        public virtual ContactCategory? ContactCategory { get; set; }
        public virtual Country? Country { get; set; }
        public virtual State? State { get; set; }
    }
}
