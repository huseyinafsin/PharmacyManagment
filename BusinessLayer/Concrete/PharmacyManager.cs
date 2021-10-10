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
    public class PharmacyManager : IPharmacyService
    {
        private readonly IPharmacyDal _pharmacyDal;

        public PharmacyManager(IPharmacyDal pharmacyDal)
        {
            _pharmacyDal = pharmacyDal;
        }

        public IResult AddPharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Add(pharmacy);
            return new SuccessResult(Messages.PharmacyAdded);
        }

        public IResult DeletePharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Delete(pharmacy);
            return new SuccessResult(Messages.PharmacyDeleted);
        }


        public IDataResult<List<Pharmacy>> GetPharmacies(Expression<Func<Pharmacy, bool>> expression)
        {
            return new SuccessDataResult<List<Pharmacy>>( _pharmacyDal.GetAll(expression), Messages.PharmacyListed);
        }

        public IDataResult<List<Pharmacy>> GetPharmaciesWithDetails(Expression<Func<Pharmacy, bool>> expression = null)
        {
            //DTO Query
            return new SuccessDataResult<List<Pharmacy>>(_pharmacyDal.GetPharmaciesWithDetails(expression),
                Messages.PharmacyListed);
        }

        public IDataResult<Pharmacy> GetPharmacy(int id)
        {
            return new SuccessDataResult<Pharmacy>( _pharmacyDal.Get(x => x.PharmacyId == id), Messages.PharmacyFetched);
        }

        public IDataResult<Pharmacy> GetSinglePharmacyWithDetails(int pharmacyId)
        {
            //DTO Query
            return new SuccessDataResult<Pharmacy>(
                _pharmacyDal.GetSinglePharmacyWithDetails(x => x.PharmacyId == pharmacyId), Messages.PharmacyFetched);
        }

        public IResult UpdatePharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Update(pharmacy);
            return new SuccessResult(Messages.PharmacyUpdated);
        }
    }
}
