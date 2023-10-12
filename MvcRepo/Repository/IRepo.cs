using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRepo.Repository
{
    public interface IRepo<T> where T : class

    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(int Id);
        T Find(int Id);
        void Insert(T t);
        void Update(T t);
    }
}
