using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.core.interfaces
{
    public interface iBaseRepository <T> where T:class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        T Add(T entity);

        T Update(T entity);
        void Delete(int id);
    }
}
