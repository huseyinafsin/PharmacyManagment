using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;


namespace DataAccessLayer.Abstract
{
    public interface IManufacturerDal: IEntityRepository<Manufacturer>
    {
    }
}
