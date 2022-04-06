
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace myApp.entitiy.LibraryEntities
{
    public class PublisherBook
    {
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
