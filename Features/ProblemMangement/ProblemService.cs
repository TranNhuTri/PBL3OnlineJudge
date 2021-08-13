using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PBL3.Features.CategoryManagement;
using PBL3.Features.SubmissionManagement;
using PBL3.Models;
using PBL3.Repositories;
using System;
using PBL3.General;

namespace PBL3.Features.ProblemManagement
{
    public class ProblemService: IProblemService
    {
        private readonly IRepository<Problem> _problemRepo;
        private readonly IRepository<PBL3.Models.Action> _actionRepo;
        private readonly IRepository<ProblemAuthor> _problemAuthorRepo;
        private readonly IRepository<ProblemClassification> _problemClassificationRepo;
        public ProblemService(IRepository<Problem> problemRepo, IRepository<PBL3.Models.Action> actionRepo, IRepository<ProblemAuthor> problemAuthor, IRepository<ProblemClassification> problemClassificationRepo)
        {
            _problemRepo = problemRepo;
            _actionRepo = actionRepo;
            _problemAuthorRepo = problemAuthor;
            _problemClassificationRepo = problemClassificationRepo;
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

        public void UpdateProblem(int problemID, Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, int accountID)
        {
            var problem =  _problemRepo.GetById(problemID);
            
            problem.problemAuthors = _problemAuthorRepo.GetAll().Where(p => p.problemID == problemID).ToList();

            problem.problemClassifications = _problemClassificationRepo.GetAll().Where(p => p.problemID == problemID).ToList();

            var action = new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = problem.ID,
                dateTime = DateTime.Now,
                typeObject = Convert.ToInt32(TypeObject.Problem)
            };

            string actionString = "Sửa ";

            if(problem.code != reqProblem.code)
                actionString += "mã bài, ";

            if(problem.title != reqProblem.title)
                actionString += "tên bài, ";

            if(problem.content != reqProblem.content)
                actionString += "đề bài, ";

            if(problem.difficulty != reqProblem.difficulty)
                actionString += "độ khó, ";

            if(problem.isPublic != reqProblem.isPublic)
                actionString += "trạng thái bài, ";

            if(problem.timeLimit != reqProblem.timeLimit)
                actionString += "thời gian giới hạn, ";

            if(problem.memoryLimit != reqProblem.memoryLimit)
                actionString += "giới hạn bộ nhớ, ";
            
            var listProblemAuthors = problem.problemAuthors.Where(p => p.isDeleted == false).ToList();

            if(Utility.DifferentList(reqListAuthorIds, listProblemAuthors.Select(p => p.authorID).ToList()))
                actionString += "tác giả, ";

            foreach(var item in listProblemAuthors)
            {
                if(reqListAuthorIds.Any(p => p == item.authorID) == false)
                {
                    item.isDeleted = true;
                    _problemAuthorRepo.Update(item);
                }
            }
            foreach(var item in reqListAuthorIds)
            {
                if(problem.problemAuthors.Any(p => p.authorID == item) == false)
                {
                    _problemAuthorRepo.Insert(new ProblemAuthor()
                    {
                        authorID = item,
                        problem = problem
                    });
                    _problemAuthorRepo.Save();
                }
                else
                {
                    var tmpt = problem.problemAuthors.FirstOrDefault(p => p.authorID == item);
                    tmpt.isDeleted = false;
                    _problemAuthorRepo.Update(tmpt);
                }
            }

            var listProblemClassifications = problem.problemClassifications.Where(p => p.isDeleted == false).ToList();

            if(Utility.DifferentList(reqListCategoryIds, listProblemClassifications.Select(p => p.categoryID).ToList()))
                actionString += "dạng bài, ";

            foreach(var item in listProblemClassifications)
            {
                if(reqListCategoryIds.Any(p => p == item.categoryID) == false)
                {
                    item.isDeleted= true;
                    _problemClassificationRepo.Update(item);
                }
            }
            foreach(var item in reqListCategoryIds)
            {
                if(problem.problemClassifications.Any(p => p.categoryID == item) == false)
                {
                    _problemClassificationRepo.Insert(new ProblemClassification()
                    {
                        categoryID = item,
                        problem = problem
                    });
                }
                else
                {
                    var tmpt = problem.problemClassifications.FirstOrDefault(p => p.categoryID == item);
                    tmpt.isDeleted = false;
                    _problemClassificationRepo.Update(tmpt);
                }
            }

            problem.code = reqProblem.code;
            problem.title = reqProblem.title;
            problem.content = reqProblem.content;
            problem.isPublic = reqProblem.isPublic;
            problem.timeLimit = reqProblem.timeLimit;
            problem.memoryLimit = reqProblem.memoryLimit;
            problem.difficulty = reqProblem.difficulty;

            action.action = actionString.Substring(0, actionString.Length - 2);

            _actionRepo.Insert(action);
            _actionRepo.Save();

            _problemRepo.Update(problem);
            _problemRepo.Save();
        }

        public void ChangeIsDeleted(int problemID)
        {
            var problem = _problemRepo.GetById(problemID);
            problem.isDeleted = true;
            _problemRepo.Update(problem);
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