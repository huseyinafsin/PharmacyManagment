﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        List<Customer> GetCustomers();

    }
}
