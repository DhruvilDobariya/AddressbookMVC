using System;
using System.Collections.Generic;

namespace Addressbook.Models
{
    public partial class City
    {
        public City()
        {
            Contacts = new HashSet<Contact>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int StateId { get; set; }
        public string? Stdcode { get; set; }
        public string? PinCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
