using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class ManufacturerManager : IManufacturerService
    {
        private readonly IManufacturerDal _manufacturerDal;

        public ManufacturerManager(IManufacturerDal manufacturerDal)
        {
            _manufacturerDal = manufacturerDal;
        }

        public IResult AddManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDal.Add(manufacturer);
            return new SuccessResult(Messages.ManufacturerAdded);
        }

        public IResult DeleteManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDal.Delete(manufacturer);
            return new SuccessResult(Messages.ManufacturerDeleted);
        }

        public IDataResult<Manufacturer> GetManufacturer(int manufacturerId)
        {
            return new SuccessDataResult<Manufacturer>(_manufacturerDal.Get(x => x.ManufacturerId == manufacturerId),
                Messages.ManufacturerFetched);
        }


        public IDataResult<List<Manufacturer>> GetManufacturers(Expression<Func<Manufacturer, bool>> expression)
        {
            return new SuccessDataResult<List<Manufacturer>>( _manufacturerDal.GetAll(expression),Messages.ManufacturerListed);
        }

        public IDataResult<List<Manufacturer>> GetManufacturersWithDetails(Expression<Func<Manufacturer, bool>> expression = null)
        {
            //DTO Query
            return new SuccessDataResult<List<Manufacturer>>(_manufacturerDal.GetManufacturersWithDetails(expression),
                Messages.ManufacturerListed);
        }

        public IDataResult<Manufacturer> GetSingleManufacturerWithDetails(int manufacturerId)
        {
            //DTO Query
            return new SuccessDataResult<Manufacturer>(
                _manufacturerDal.GetSingleManufacturerWithDetails(x => x.ManufacturerId == manufacturerId));
        }

        public IResult UpdateManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDal.Update(manufacturer);
            return new SuccessResult(Messages.ManufacturerUpdated);
        }
    }
}
