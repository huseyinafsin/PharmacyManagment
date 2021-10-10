using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EfPharmacyRepository : EfEntityRepositoryBase<Pharmacy, PharmacyManagmentContext>, IPharmacyDal
    {
      
    }
}
