using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using optionspattern.Models;
using optionspattern.optionspattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace optionspattern.Controllers
{
    public class HomeController : Controller
    {
        private IBook Book;

        public HomeController(IBook book)
        {
            Book = book;
            Index();
        }

        public void Index()
        {
            Console.WriteLine(Book.MyProperty2);
        }
    }
}
