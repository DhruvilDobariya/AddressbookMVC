using System;
using System.Collections.Generic;

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
        public string StateName { get; set; } = null!;
        public int CountryId { get; set; }
        public string? StateCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
