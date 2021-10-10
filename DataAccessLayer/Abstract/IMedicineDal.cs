


using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccessLayer.Abstract
{
    public interface IMedicineDal: IEntityRepository<Medicine>
    {
        List<Medicine> GetMedicinesWithDetails(Expression<Func<Medicine, bool>> expression = null);
        Medicine GetSingleMedicineWithDetails(Expression<Func<Medicine, bool>> expression);
    }
}
