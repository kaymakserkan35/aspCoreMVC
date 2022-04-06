
using myApp.entitiy.LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.business.Abstract
{
    public interface IBookService
    {
        void Create(Book entity);
        void ReadById(int id);
        List<Book> ReadAll();
        void Update(Book entity);
        void Delete(Book entity);



    }
}
