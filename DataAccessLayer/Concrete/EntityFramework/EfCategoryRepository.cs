using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository: EfEntityRepositoryBase<Category, PharmacyManagmentContext>, ICategoryDal
    {
    }
}
