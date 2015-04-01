using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Implementations.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext m_Context;

        public Repository(DbContext context)
        {
            m_Context = context;
        }

        public T Create(T entity)
        {
            return m_Context.Set<T>().Add(entity);
        }

        public T Update(T entity)
        {
            m_Context.Set<T>().Attach(entity);
            m_Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(T entity)
        {
            m_Context.Set<T>().Remove(entity);
        }

        public T GetById(Guid id)
        {
            return m_Context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return m_Context.Set<T>().ToList();
        }

        public void Attach(T entity)
        {
            m_Context.Set<T>().Attach(entity);
        }

        public int Count
        {
            get
            {
                return m_Context.Set<T>().Count();
            }
        }
    }
}
