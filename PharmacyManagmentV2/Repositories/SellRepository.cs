﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Entities;
using PharmacyManagmentV2.Interfaces;

namespace PharmacyManagmentV2.Repositories
{
    public class SellRepository : GenericRepository<Sell>, ISellRepository
    {
        public SellRepository(AppDBContext context) : base(context)
        {
        }
    }
}
