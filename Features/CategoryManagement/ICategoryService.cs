using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.CategoryManagement
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories(); // get all non deleted categories
        List<Category> GetAllDeletedCategories();
        List<int> GetListCategoriesByProblemID(int problemID);
        void ChangeIsDeletedCategory(int categoryID); // hard delete
    }
}