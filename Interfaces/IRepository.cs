using CharityApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        IQueryable<T> Collection();
        void Insert(T t);
        void Delete(int Id);
        void Update(T t);
        T Find(int Id);
        void Save();
    }
}
