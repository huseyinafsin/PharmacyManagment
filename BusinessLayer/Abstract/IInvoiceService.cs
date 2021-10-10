using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IInvoiceService
    {
        IResult AddInvoice(Invoice invoice);
        IResult DeleteInvoice(Invoice invoice);
        IResult UpdateInvoice(Invoice invoice);
        IDataResult<List<Invoice>> GetInvoices(Expression<Func<Invoice, bool>> expression=null);
        IDataResult<List<Invoice>> GetInvoicesWithDetails(Expression<Func<Invoice, bool>> expression=null);
        IDataResult<Invoice> GetInvoice(int invoinceId);
        IDataResult<Invoice> GetSingleInvoiceWithDetails(int invoinceId);
    }
}
