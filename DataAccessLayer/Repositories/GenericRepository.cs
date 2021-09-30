using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{ 
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

       
        public T GetById(int id)
        {
            using var _context = new Context();
            return _context.Set<T>().Find(id);
        }

        public void Create(T obj)
        {
            using var _context = new Context();
            _context.Set<T>().AddAsync(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            using var _context = new Context();
            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            using var _context = new Context();
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
            using var _context = new Context();
            return  _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            using var _context = new Context();
            return  _context.Set<T>().Where(expression).ToList();
        }
    }
}
