using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.dataaccess.Repository
{
    public  interface IRepository<TEntity>
        {
            void Create(TEntity entity);
            void ReadById(int id);
            List<TEntity> ReadAll();
            void Update(TEntity entity);
            void Delete(TEntity entity);
        }
    
}
