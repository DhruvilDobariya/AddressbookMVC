using Addressbook.Models;

namespace Addressbook.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookContext _db;
        public string Message { get; set; }

        public ContactRepository(AddressBookContext db)
        {
            _db = db;
        }

        public IEnumerable<Contact> GetAllWithJoin()
        {
            IQueryable<Contact> contacts = from Contact in _db.Contacts
                                           join ContactCategory in _db.ContactCategories on Contact.ContactCategoryId equals ContactCategory.ContactCategoryId
                                           join City in _db.Cities on Contact.CityId equals City.CityId
                                           join State in _db.States on Contact.StateId equals State.StateId
                                           join Country in _db.Countries on Contact.CountryId equals Country.CountryId
                                           select new Contact
                                           {
                                               ContactId = Contact.ContactId,
                                               ContactName = Contact.ContactName,
                                               ContactNo = Contact.ContactNo,
                                               WhatsAppNo = Contact.WhatsAppNo,
                                               Email = Contact.Email,
                                               BirthDate = Contact.BirthDate,
                                               Age = Contact.Age,
                                               BloodGroup = Contact.BloodGroup,
                                               FacebookId = Contact.FacebookId,
                                               LinkedInId = Contact.LinkedInId,
                                               Address = Contact.Address,
                                               ContactCategory = Contact.ContactCategory,
                                               CreationDate = Contact.CreationDate,
                                               City = City,
                                               State = State,
                                               Country = Country
                                           };
            return contacts;
        }
    }
}
