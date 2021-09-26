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
    public class EFTypeRepository : GenericRepository<MedicineType>, ITypeDal
    {
        public void Delete(Func<int, MedicineType> getMedicineType)
        {
            throw new NotImplementedException();
        }
    }
}
