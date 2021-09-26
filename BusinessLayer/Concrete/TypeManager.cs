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
    public class TypeManager : ITypeService
    {

        ITypeDal _typeDal;

        public TypeManager(ITypeDal typeDal)
        {
            _typeDal = typeDal;
        }

        public void AddType(MedicineType type)
        {
            _typeDal.Create(type);
        }

        public void DeleteType(MedicineType type)
        {
            _typeDal.Delete(type);
        }

        public MedicineType GetType(int id)
        {
            return _typeDal.GetById(id);
                
        }

        public List<MedicineType> GetTypes()
        {
            return _typeDal.GetAll();
            
        }

        public List<MedicineType> GetTypes(Expression<Func<MedicineType, bool>> expression)
        {
            return _typeDal.GetAll(expression);
        }

        public void UpdateType(MedicineType medicineType)
        {
            _typeDal.Update(medicineType);
        }

       
    }
}
