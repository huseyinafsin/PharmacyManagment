﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{ 
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
    {

       
        public async Task<T> GetById(int id)
        {
            using var _context = new AppDBContext();
            return await _context.Set<T>().AsNoTracking()
                                          .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(T obj)
        {
            using var _context = new AppDBContext();
            await _context.Set<T>().AddAsync(obj);
            _context.SaveChanges();
        }

        public async Task Update(T obj)
        {
            using var _context = new AppDBContext();
            _context.Update(obj);
            _context.SaveChanges();
        }

        public async Task Delete(T obj)
        {
            using var _context = new AppDBContext();
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();

        }

        public async Task<IQueryable<T>> GetAll()
        {
            using var _context = new AppDBContext();
            return  _context.Set<T>().AsNoTracking();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            using var _context = new AppDBContext();
          return  _context.Set<T>().Where(expression).ToList();
        }
    }
}
