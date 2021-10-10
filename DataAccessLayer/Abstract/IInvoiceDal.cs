using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityLayer.Concrete;


namespace DataAccessLayer.Abstract
{
    public interface IInvoiceDal: IEntityRepository<Invoice>
    {
        List<Invoice> GetInvoicesWithDetails(Expression<Func<Invoice, bool>> expression = null);
        Invoice GetSingleInvoiceWithDetails(Expression<Func<Invoice, bool>> expression);
    }
}
