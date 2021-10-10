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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult DeleteCategory(Category category)
        {
             _categoryDal.Delete(category);
             return new SuccessResult(Messages.BankAccountDeleted);
        }

  
        public IDataResult<List<Category>> GetCategories(Expression<Func<Category, bool>> expression)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(expression),Messages.CategoryListed);
        }


        public IDataResult<Category> GetCategory(int id)
        {
            return new SuccessDataResult<Category>( _categoryDal.Get(x => x.CategoryId == id),Messages.CategoryFetched);
        }


        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}

