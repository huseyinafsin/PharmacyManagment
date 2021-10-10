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
    public class PurchaseManager : IPurchaseService
    {

        private readonly IPurchaseDal _purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }

        public IResult AddPurchase(Purchase purchase)
        {
             _purchaseDal.Add(purchase);
             return new SuccessResult(Messages.PurchaseAdded);
        }

        public IResult DeletePurchase(Purchase purchase)
        {
            _purchaseDal.Delete(purchase);
            return new SuccessResult(Messages.PurchaseDeleted);
        }

        public IDataResult<Purchase> GetPurchase(int id)
        {
            return new SuccessDataResult<Purchase>( _purchaseDal.Get(x=>x.PurchaseId==id), Messages.PurchaseFetched);
        }


        public IDataResult<List<Purchase>> GetPurchases(Expression<Func<Purchase, bool>> expression)
        {
            return new SuccessDataResult<List<Purchase>>(_purchaseDal.GetAll(expression), Messages.PurchaseListed);
        }

        public IDataResult<List<Purchase>> GetPurchasesWithDetails(Expression<Func<Purchase, bool>> expression = null)
        {
            //DTO Query
            return new SuccessDataResult<List<Purchase>>(_purchaseDal.GetPurchasesWithDetails(expression),
                Messages.PurchaseListed);
        }

        public IDataResult<Purchase> GetSinglePurchaseWithDetails(int purchaseId)
        {
            //DTO Query
            return new SuccessDataResult<Purchase>(
                _purchaseDal.GetSinglePurchaseWithDetails(x => x.PurchaseId == purchaseId), Messages.PurchaseFetched);
        }

        public IResult UpdatePurchase(Purchase purchase)
        {
            _purchaseDal.Update(purchase);
            return new SuccessResult(Messages.PurchaseUpdated);
        }
    }
}
