using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {
        IResult AddCategory(Category category);
        IResult DeleteCategory(Category category);
        IResult UpdateCategory(Category category);
        IDataResult<List<Category>> GetCategories(Expression<Func<Category, bool>> expression=null);
        IDataResult<Category> GetCategory(int categoryId);
    }
}
