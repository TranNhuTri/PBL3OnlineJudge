using System.Collections.Generic;
using System.Linq;
using PBL3.Features.ProblemManagement;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.CategoryManagement
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo) 
        {
            _categoryRepo = categoryRepo;
        }
       
        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }
        
        public Category GetCategoryByID(int categoryID)
        {
            return _categoryRepo.GetById(categoryID);
        }
        public void AddCategory(Category category)
        {
            _categoryRepo.Insert(category);
            _categoryRepo.Save();
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepo.Update(category);
            _categoryRepo.Save();
        }
        public void DeleteCategory(int categoryID)
        {
            _categoryRepo.Delete(categoryID);
            _categoryRepo.Save();
        }
    }
}