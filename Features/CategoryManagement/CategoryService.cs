using System;
using System.Collections.Generic;
using System.Linq;
using PBL3.Features.ActionManagemant;
using PBL3.Features.ProblemManagement;
using PBL3.General;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.CategoryManagement
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<ProblemClassification> _problemClassificationRepo;
        private readonly IActionService _actionService;
        public CategoryService(IRepository<Category> categoryRepo, IRepository<ProblemClassification> problemClassificationRepo, IActionService actionService) 
        {
            _categoryRepo = categoryRepo;
            _problemClassificationRepo = problemClassificationRepo;
            _actionService = actionService;
        }
       
        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }
        public List<Category> GetAllDeletedCategories()
        {
            return _categoryRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }
        
        public List<Category> GetCategoriesByName(string txt)
        {
            return _categoryRepo.GetAll().Where(p => p.name.ToLower().Contains(txt.ToLower())).ToList();
        }

        public Category GetCategoryByName(string txt)
        {
            return _categoryRepo.GetAll().FirstOrDefault(p => p.name == txt);
        }
        public Category GetCategoryByID(int categoryID)
        {
            return _categoryRepo.GetById(categoryID);
        }
        public void AddCategory(Category category, List<int> reqListProblemIds, int accountID)
        {
            foreach(int id in reqListProblemIds)
            {
                var problemClassification = new ProblemClassification()
                {
                    problemID = id,
                    category = category
                };
                _problemClassificationRepo.Insert(problemClassification);
            }
            _problemClassificationRepo.Save();

            _actionService.AddAction(new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = category.ID,
                dateTime = DateTime.Now,
                action = "Tạo mới",
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            });
        }
        public void UpdateCategory(int id, Category category, List<int> reqListProblemIds, int accountID)
        {
            var problemCategory = _categoryRepo.GetById(id);
            var listProblemClassifications = _problemClassificationRepo.GetAll()
            .Where(pc => pc.categoryID == id && pc.isDeleted == false).ToList();

            if(Utility.DifferentList(reqListProblemIds, listProblemClassifications.Select(p => p.problemID).ToList()))
            {
                _actionService.AddAction(new PBL3.Models.Action()
                {
                    accountID = accountID,
                    objectID = id,
                    dateTime = DateTime.Now,
                    action = "Sửa danh sách bài tập",
                    typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                });
            }

            foreach(var item in listProblemClassifications)
            {
                //xoa
                if(reqListProblemIds.Any(p => p == item.problemID) == false)
                {
                    item.isDeleted = true;
                    _problemClassificationRepo.Update(item);
                }
            }
            foreach(var item in reqListProblemIds)
            {
                //them
                if(listProblemClassifications.Any(p => p.problemID == item) == false)
                {
                    _problemClassificationRepo.Insert(new ProblemClassification()
                    {
                        problemID = item,
                        categoryID = id
                    });
                }
                else
                {
                    var tmpt = listProblemClassifications.FirstOrDefault(p => p.problemID == item);
                    tmpt.isDeleted = false;
                    _problemClassificationRepo.Update(tmpt);
                }
            }

            if(problemCategory.name != category.name)
            {
                problemCategory.name = category.name;
                _actionService.AddAction(new PBL3.Models.Action()
                {
                    accountID = accountID,
                    objectID = id,
                    dateTime = DateTime.Now,
                    action = "Sửa tên dạng bài",
                    typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                });
            }
            _categoryRepo.Update(problemCategory);
            _categoryRepo.Save();
        }
        public void ChangeIsDeletedCategory(int categoryID, int accountID)
        {
            Category category = this.GetCategoryByID(categoryID);
            var action = new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = category.ID,
                dateTime = DateTime.Now,
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            };
            if(category.isDeleted == true)
                action.action = "Khôi phục dạng bài";
            else
                action.action = "Xóa dạng bài";
            
            _actionService.AddAction(action);
            
            category.isDeleted = !category.isDeleted;
            _categoryRepo.Update(category);
            _categoryRepo.Save();
        }
    }
}