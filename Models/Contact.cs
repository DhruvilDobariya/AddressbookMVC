using System;
using System.Collections.Generic;

namespace Addressbook.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = null!;
        public int ContactCategoryId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ContactNo { get; set; } = null!;
        public string? WhatsAppNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; } = null!;
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public string? BloodGroup { get; set; }
        public string? FacebookId { get; set; }
        public string? LinkedInId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ContactCategory ContactCategory { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual State State { get; set; } = null!;
    }
}
