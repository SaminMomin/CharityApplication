using CharityApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CharityApplication.Models
{
    public class SQLRepository<T> : IRepository<T> where T:BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository (DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public T Find(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}