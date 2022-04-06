using myApp.dataaccess.context;
using myApp.entitiy.LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.dataaccess.Repository
{
    public class EfCoreBookRepository : IBookRepository
    {



        public void Create(Book entity)
        {
            using (var context = new LibraryContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public List<Book> ReadAll()
        {
            using (var context = new LibraryContext())
            {
                return context.Books.ToList();
            }
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
