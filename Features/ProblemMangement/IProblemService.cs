using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PBL3.Models;

namespace PBL3.Features.ProblemManagement
{
    public interface IProblemService
    {
        List<Problem> GetAllProblems();
        Problem GetProblemByID(int problemID);
        void AddProblem(Problem problem);
        void UpdateProblem(Problem problem);
        void DeleteProblem(int problemID);
        List<Problem> GetListSearchProblem(string problemName, List<int> categoryIDs, int? minDifficult, int? maxDifficult);
    }
}