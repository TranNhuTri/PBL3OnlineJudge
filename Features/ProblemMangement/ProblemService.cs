using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PBL3.Features.CategoryManagement;
using PBL3.Features.SubmissionManagement;
using PBL3.Models;
using PBL3.Repositories;
using System;


namespace PBL3.Features.ProblemManagement
{
    public class ProblemService: IProblemService
    {
        private readonly IRepository<Problem> _problemRepo;
        public ProblemService(IRepository<Problem> problemRepo)
        {
            _problemRepo = problemRepo;
        }
        public List<Problem> GetAllProblems() 
        {
            return _problemRepo.GetAll().ToList();
        }
        public Problem GetProblemByID(int problemID)
        {
            return _problemRepo.GetById(problemID);
        }

        public void AddProblem(Problem problem)
        {
            _problemRepo.Insert(problem);
            _problemRepo.Save();
        }

        public void UpdateProblem(Problem problem)
        {
            _problemRepo.Update(problem);
            _problemRepo.Save();
        }

        public void DeleteProblem(int problemID)
        {
            _problemRepo.Delete(problemID);
            _problemRepo.Save();
        }

        public List<Problem> GetListSearchProblem(string problemName, List<int> categoryIDs, int? minDifficult, int? maxDifficult)
        {
            List<Problem> problems = new List<Problem>();
            foreach(Problem item in _problemRepo.GetAll().ToList())
            {
                List<int> categoriesIDsOfProblem = item.problemClassifications.Select(p => p.categoryID).ToList();
                if (problemName != null && !item.title.Contains(problemName)) continue;
                bool checkCategory = false;
                if (categoryIDs.Count == 0)
                    checkCategory = true;
                else 
                {
                    foreach(int i in categoriesIDsOfProblem) 
                        if (categoryIDs.Contains(i))
                            checkCategory = true;
                }
                bool checkDifficult = false;
                if (minDifficult == null) minDifficult = 0;
                if (maxDifficult == null) maxDifficult = (int)1e9;
                if (item.difficulty >= minDifficult && item.difficulty <= maxDifficult)
                    checkDifficult = true;
                if (checkCategory && checkDifficult)
                    problems.Add(item);
                
            }
            return problems;
        }
    }
}