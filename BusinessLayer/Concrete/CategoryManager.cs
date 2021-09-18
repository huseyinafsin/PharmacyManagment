using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EFCategoryRepository eFCategoryRepository;

        public CategoryManager()
        {
            eFCategoryRepository = new EFCategoryRepository();
        }

        public void AddCategory(Category category)
        {
            _ = eFCategoryRepository.Create(category);
        }

        public void DeleteCategory(Category category)
        {
            _ = eFCategoryRepository.Delete(category);
        }

        public List<Category> GetCategories()
        {
            return eFCategoryRepository.GetAll().ToList();
        }

        public Category GetCategory(int id)
        {
            return eFCategoryRepository.GetById(id).Result;
        }

        public void UpdateCategory(Category category)
        {
            _ = eFCategoryRepository.Update(category);
        }
    }
}
