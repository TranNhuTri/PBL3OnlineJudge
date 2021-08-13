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
        private readonly IRepository<ProblemClassification> _problemClassificationRepo;
        public CategoryService(IRepository<Category> categoryRepo, IRepository<ProblemClassification> problemClassificationRepo) 
        {
            _categoryRepo = categoryRepo;
            _problemClassificationRepo = problemClassificationRepo;
        }
       
        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }
        public List<Category> GetAllDeletedCategories()
        {
            return _categoryRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }
        public List<int> GetListCategoriesByProblemID(int problemID)
        {
            return _problemClassificationRepo.GetAll().Where(p => p.problemID == problemID).Select(p => p.categoryID).ToList();
        }
        public void ChangeIsDeletedCategory(int categoryID)
        {
            Category category = _categoryRepo.GetById(categoryID);
            category.isDeleted = !category.isDeleted;
            _categoryRepo.Update(category);
            _categoryRepo.Save();
        }
    }
}