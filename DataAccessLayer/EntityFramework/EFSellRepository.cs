using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace PharmacyManagmentV2.Repositories
{
    public class EFSellRepository : GenericRepository<Invoice>, ISellDal
    {
      
    }
}
