using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityLayer.Concrete;

 namespace DataAccessLayer.Abstract
{
    public interface IAddressDal : IEntityRepository<Address>
    {

    }
}
