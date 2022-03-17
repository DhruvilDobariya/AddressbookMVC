using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Addressbook.Models
{
    [Index(nameof(ContactCategoryName), IsUnique = true)]
    public partial class ContactCategory
    {
        public ContactCategory()
        {
            Contacts = new HashSet<Contact>();
        }

        public int ContactCategoryId { get; set; }

        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Enter Contact Category")]
        public string ContactCategoryName { get; set; } = null!;
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
