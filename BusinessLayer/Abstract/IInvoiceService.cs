using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IInvoiceService
    {
        void AddInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        Task<IQueryable<Invoice>>  GetInvoices();
        List<Invoice> GetInvoices(Expression<Func<Invoice, bool>> expression);
        Invoice GetInvoice(int id);
    }
}
