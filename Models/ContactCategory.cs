using System;
using System.Collections.Generic;

namespace Addressbook.Models
{
    public partial class ContactCategory
    {
        public ContactCategory()
        {
            Contacts = new HashSet<Contact>();
        }

        public int ContactCategoryId { get; set; }
        public string ContactCategoryName { get; set; } = null!;
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
