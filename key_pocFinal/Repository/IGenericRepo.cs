using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_pocFinal.Repository
{
    interface IGenericRepo<T> where T : class
    {
        T get(int id);
        IEnumerable<T> getAll();

        void Create(T entity);

        void Delete(T entity);
    }
}
