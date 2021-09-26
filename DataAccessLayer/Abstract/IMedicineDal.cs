


using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMedicineDal: IGenericDal<Medicine>
    {
        List<Medicine> GetMedicinesWithProperties();
        Medicine GetMedicinewithProperties(int id);
    }
}
