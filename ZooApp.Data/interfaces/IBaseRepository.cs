using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Data.interfaces
{
    public interface IBaseRepository<T>
    {

        public T Create(T entity);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public T Update(T entity);
        public T Delete(int id);
    }
}
