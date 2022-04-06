using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uı.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }




    }
}
