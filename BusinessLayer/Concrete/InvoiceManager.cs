using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;
        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }
        public IResult AddInvoice(Invoice invoice)
        {
            _invoiceDal.Add(invoice);
            return new SuccessResult(Messages.InvoiceAdded);
        }

        public IResult DeleteInvoice(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);
            return new SuccessResult(Messages.InvoiceDeleted);
        }

        public IDataResult<Invoice> GetInvoice(int id)
        {
           return new SuccessDataResult<Invoice>( _invoiceDal.Get(x => x.InvoiceId == id),Messages.InvoiceFetched);
        }


        public IDataResult<List<Invoice>> GetInvoices(Expression<Func<Invoice, bool>> expression)
        {
            return new SuccessDataResult<List<Invoice>>( _invoiceDal.GetAll(expression),Messages.InvoiceListed);
        }

        public IDataResult<List<Invoice>> GetInvoicesWithDetails(Expression<Func<Invoice, bool>> expression = null)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetInvoicesWithDetails(expression),
                Messages.InvoiceListed);
        }

        public IDataResult<Invoice> GetSingleInvoiceWithDetails(int invoiceId)
        {
            return new SuccessDataResult<Invoice>(
                _invoiceDal.GetSingleInvoiceWithDetails(x => x.InvoiceId == invoiceId), Messages.InvoiceFetched);
        }

        public IResult UpdateInvoice(Invoice invoice)
        {
            _invoiceDal.Update(invoice);
            return new SuccessResult(Messages.InvoiceUpdated);

        }
    }
}
