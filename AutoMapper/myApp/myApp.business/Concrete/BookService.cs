using myApp.business.Abstract;
using myApp.dataaccess.Repository;
using myApp.entitiy.LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.business.Concrete
{
    public class BookService : IBookService
    {
        private IBookRepository    bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Create(Book entity)
        {
            bookRepository.Create(entity);
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public List<Book> ReadAll()
        {
            return bookRepository.ReadAll();
        }

        public void ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
