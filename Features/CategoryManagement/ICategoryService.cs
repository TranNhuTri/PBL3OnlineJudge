using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.CategoryManagement
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryByID(int categoryID);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryID);
    }
}