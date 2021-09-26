using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoiceDal;
        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }
        public void AddInvoice(Invoice invoice)
        {
            _invoiceDal.Create(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);
        }

        public Invoice GetInvoice(int id)
        {
           return _invoiceDal.GetById(id);
        }

        public List<Invoice> GetInvoices()
        {
            return _invoiceDal.GetAll();
        }

        public List<Invoice> GetInvoices(Expression<Func<Invoice, bool>> expression)
        {
            return _invoiceDal.GetAll(expression);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceDal.Update(invoice);
        }
    }
}
