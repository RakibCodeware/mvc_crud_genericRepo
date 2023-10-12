using MvcRepo.DataContext;
using MvcRepo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcRepo.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private RepoDbEntities _context;
        private  IDbSet<T> _dbSet;

        public Repo()
        {
            _context =new RepoDbEntities();
            _dbSet = _context.Set<T>();


        }

        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var t = Find(Id);
            if (_context.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }

            _dbSet.Remove(t);
        }

        public T Find(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
        }

        public void Update(T t)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}