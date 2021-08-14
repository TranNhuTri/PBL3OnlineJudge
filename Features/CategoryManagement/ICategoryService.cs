using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.CategoryManagement
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        List<Category> GetAllDeletedCategories();
        List<Category> GetCategoriesByName(string txt);
        Category GetCategoryByName(string txt);
        Category GetCategoryByID(int categoryID);
        void AddCategory(Category category, List<int> reqListProblemIds, int accountID);
        void UpdateCategory(int id, Category category, List<int> reqListProblemIds, int accountID);
        void ChangeIsDeletedCategory(int categoryID, int accountID);
    }
}