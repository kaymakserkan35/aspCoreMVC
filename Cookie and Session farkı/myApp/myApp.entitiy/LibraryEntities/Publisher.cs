using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.entitiy.LibraryEntities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        
        public List<PublisherBook> PublisherBooks { get; set; }

    }
}
