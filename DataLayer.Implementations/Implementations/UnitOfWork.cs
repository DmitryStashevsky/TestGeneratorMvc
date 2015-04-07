using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer.Implementations.ApplicationDbContext;
using DataLayer.Interfaces;

namespace DataLayer.Implementations.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext m_Context;

        public UnitOfWork(DbContext context)
        {
            m_Context = context;
        }

        public void SaveChanges()
        {
            m_Context.SaveChanges();
        }

        public T GetRepository<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }
    }
}
