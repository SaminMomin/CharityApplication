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
            var obj = Find(Id);
            if(context.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);

        }

        public T Find(int Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
         }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
            //throw new NotImplementedException();
        }
    }
}