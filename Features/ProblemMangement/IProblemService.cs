using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.ProblemManagement
{
    public interface IProblemService
    {
        List<Problem> GetAllProblems(); // get all non deleted problems
        List<Problem> GetAllDeletedProblems();
        List<Problem> GetUnsolvedProblemsByAccountID(List<Problem> problems, int accountID);
        List<Problem> GetListProblems(string problemName, List<int> categoryIds, int? minDifficult, int? maxDifficult);
        void ChangeIsDeletedProblem(int problemID); // soft delete
    }
}