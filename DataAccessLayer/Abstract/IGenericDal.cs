using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll( Expression< Func<T,bool>> expression );
        T GetById(int id);
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

    }
}
