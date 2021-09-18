﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Create(T obj);
        Task Update(T obj);
        Task Delete(T obj);

    }
}
