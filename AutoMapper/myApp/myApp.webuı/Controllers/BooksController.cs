using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myApp.business.Abstract;
using myApp.business.Concrete;
using myApp.entitiy.LibraryEntities;
using myApp.webuı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.webuı.Controllers
{
    public class BooksController : Controller
    {
        private IMapper mapper;
        private IBookService bookService;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }


        public IActionResult ListBooks()
        {
            var books = bookService.ReadAll();
            var Modelbooks = mapper.Map<List<BookModel>>(books);
            return View(Modelbooks);
        }


        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            bookService.Create(book);
            return View();
        }
    }
}
