using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfPurchaseRepository : EfEntityRepositoryBase<Purchase, PharmacyManagmentContext>, IPurchaseDal
    {

       
    }
}
