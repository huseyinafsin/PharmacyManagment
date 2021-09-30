using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : Abstract.ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Create(category);
        }

        public void DeleteCategory(Category category)
        {
             _categoryDal.Delete(category);
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetCategories(Expression<Func<Category, bool>> expression)
        {
            return _categoryDal.GetAll(expression).ToList();
        }

        public Category GetCategory(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
