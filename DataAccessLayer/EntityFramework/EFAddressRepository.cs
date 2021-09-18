﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

using PharmacyManagmentV2.Repositories;

namespace DataAccessLayer.EntityFramework
{
    public class EFAddressRepository : GenericRepository<Address>, IAddressDal
    {
             
    }
}
