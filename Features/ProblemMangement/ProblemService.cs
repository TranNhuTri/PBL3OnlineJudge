using System.Collections.Generic;
using System.Linq;
using PBL3.Features.CategoryManagement;
using PBL3.Features.SubmissionManagement;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.ProblemManagement
{
    public class ProblemService: IProblemService
    {
        private readonly IRepository<Problem> _problemRepo;
        private readonly ISubmissionService _submissionService;
        private readonly ICategoryService _categoryService;
        public ProblemService(IRepository<Problem> problemRepo, ISubmissionService submissionService, ICategoryService categoryService)
        {
            _problemRepo = problemRepo;
            _submissionService = submissionService;
            _categoryService = categoryService;
        }
        public List<Problem> GetAllProblems() // get all non deleted problems
        {
            return _problemRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }
        public List<Problem> GetAllDeletedProblems()
        {
            return this.GetAllProblems().Where(p => p.isDeleted == true).ToList();
        }
        public List<Problem> GetUnsolvedProblemsByAccountID(List<Problem> problems, int accountID)
        {
            return problems.Where(p => _submissionService.GetProblemACSubmissionsByAccountID(p.ID, accountID).Count == 0).ToList();
        }
        public List<Problem> GetListProblems(string problemName, List<int> categoryIds, int? minDifficult, int? maxDifficult)
        {
            return _problemRepo.GetAll().Where(p => p.isDeleted == false).ToList();
            var problems =  _problemRepo.GetAll().Where(p => p.isDeleted == false).ToList();
            
            return problems;
            problems = problems.Where(p => string.IsNullOrEmpty(problemName) || p.title.ToLower().Contains(problemName.ToLower())).ToList();
            
            var tmptProblems = new List<Problem>();
            foreach(Problem item in problems)
            {
                List<int> lstCategoryIDs = _categoryService.GetListCategoriesByProblemID(item.ID);
                
                bool check = false;

                foreach (int iter in lstCategoryIDs)
                    if (categoryIds.Contains(iter)) check = true;
                
                if(minDifficult == null)
                    minDifficult = 0;

                if(maxDifficult == null)
                    maxDifficult = (int)1e9;
                
                if (check || lstCategoryIDs.Count == 0 || categoryIds.Count == 0)
                    if (item.difficulty >= minDifficult && item.difficulty <= maxDifficult)
                        tmptProblems.Add(item);
            }

            return tmptProblems; 
        }
        public void ChangeIsDeletedProblem(int problemID)
        {
            Problem problem = _problemRepo.GetById(problemID);
            problem.isDeleted = !problem.isDeleted;
            _problemRepo.Update(problem);
            _problemRepo.Save();
        }
    }
}