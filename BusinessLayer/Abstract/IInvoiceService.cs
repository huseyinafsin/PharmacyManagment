using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IInvoiceService
    {
        void AddInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        List<Invoice> GetInvoices();
        Invoice GetInvoice(int id);
    }
}
