using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace myApp.entitiy.LibraryEntities
{
    public class Author
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

        

        public List<Book> Books { get; set; }
      
        public List<Adress> Adresses { get; set; }



    }
}
