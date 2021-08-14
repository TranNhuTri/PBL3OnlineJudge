using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PBL3.Models;

namespace PBL3.Features.ProblemManagement
{
    public interface IProblemService
    {
        List<Problem> GetAllProblems();
        List<Problem> GetAllDeletedProblems();
        Problem GetProblemByID(int problemID);
        Problem GetNonDeletedProblemByCode(string problemCode);
        Problem GetNonDeletedProblemByTitle(string problemTitle);
        void AddProblem(Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, int accountID);
        void UpdateProblem(int problemID, Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, int accountID);
        void ChangeIsDeleted(int problemID, int accoutID);
        List<Problem> GetListSearchProblem(string problemName, List<int> categoryIDs, int? minDifficult, int? maxDifficult);
    }
}