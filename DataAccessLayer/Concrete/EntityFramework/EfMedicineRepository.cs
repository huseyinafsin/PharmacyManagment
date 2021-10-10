using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMedicineRepository : EfEntityRepositoryBase<Medicine, PharmacyManagmentContext>, IMedicineDal
    {
        public List<Medicine> GetMedicinesWithDetails(Expression<Func<Medicine, bool>> expression = null)
        {
            using (PharmacyManagmentContext context= new PharmacyManagmentContext())
            {
                return expression == null
                    ? context.Medicines
                        .Include(x => x.Category)
                        .Include(x => x.Leaf)
                        .Include(x => x.Manufacturer)
                        .Include(x => x.Type)
                        .Include(x => x.Unit)
                        .ToList()
                    
                    :   context.Medicines
                        .Include(x => x.Category)
                        .Include(x => x.Leaf)
                        .Include(x => x.Manufacturer)
                        .Include(x => x.Type)
                        .Include(x => x.Unit)
                        .Where(expression)
                        .ToList();


            }
        }

        public Medicine GetSingleMedicineWithDetails(Expression<Func<Medicine, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
