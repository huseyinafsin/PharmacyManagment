﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Repositories
{
    public class LeafRepository : GenericRepository<Leaf>, ILeafRepository
    {
        public LeafRepository(AppDBContext context) : base(context)
        {
        }
    }
}