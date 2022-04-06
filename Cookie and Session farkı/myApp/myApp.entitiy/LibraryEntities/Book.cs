using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.entitiy.LibraryEntities
{
    public class Book
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }


        public List<CategoryBook> CategoryBooks { get; set; }

        public List<PublisherBook> PublisherBooks { get; set; }




    }
}
