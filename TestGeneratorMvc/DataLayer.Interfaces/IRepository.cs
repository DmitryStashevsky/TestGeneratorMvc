using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);

        T GetById(Guid id);

        List<T> GetAll();
    }
}
