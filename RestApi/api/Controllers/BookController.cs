using data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext libraryContext;

        public BookController(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Book> Books()
        {
            var result = libraryContext.Books.ToList();
            return result;
        }
    }
}
