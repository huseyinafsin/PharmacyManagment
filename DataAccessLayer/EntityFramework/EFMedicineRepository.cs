using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EFMedicineRepository : GenericRepository<Medicine>, IMedicineDal
    {
        public List<Medicine> GetMedicinesWithProperties()
        {
            using var c = new AppDBContext();

            return c.Medicines
                .Include(x => x.Category)
                .Include(x => x.Leaf)
                .Include(x => x.Manufacturer)
                .Include(x => x.Type)
                .Include(x => x.Unit)
                .ToList();
                
        }

        public Medicine GetMedicinewithProperties(int id)
        {
            using var c = new AppDBContext();

            return c.Medicines
                .Include(x => x.Category)
                .Include(x => x.Leaf)
                .Include(x => x.Manufacturer)
                .Include(x => x.Type)
                .Include(x => x.Unit)
                .FirstOrDefault(x => x.MedicineId == id);
        }
      
    }
}
