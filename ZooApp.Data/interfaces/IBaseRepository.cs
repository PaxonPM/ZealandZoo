using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Data.interfaces
{
    public interface IBaseRepository<T>
    {

        public string Create(T entity);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public string Update(T entity);
        public string Delete(int id);
    }
}
