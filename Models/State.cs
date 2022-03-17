using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Addressbook.Models
{
    [Index(nameof(StateName), IsUnique = true)]
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Contacts = new HashSet<Contact>();
        }

        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; } = null!;

        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Select Country Name")]
        public int CountryId { get; set; }

        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please Enter State Code")]
        public string? StateCode { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}

/*
 * We can use three different way to give foreign key.
 * 1)
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorFK { get; set; }
    }

  * 2)
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [ForeignKey("AuthorFK")]
        public Author Author { get; set; }
        public int AuthorFK { get; set; }
    }

 * 3)
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("AuthorFK")]
        public ICollection<Book> Books { get; set; }
    }
*/