using System;
using System.Collections.Generic;

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
        public string? CountryName { get; set; }
        public string CountryCode { get; set; } = null!;
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
