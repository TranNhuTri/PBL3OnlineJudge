using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.SubmissionManagement
{
    public interface ISubmissionService
    {
        List<Submission> GetProblemSubmissions(int problemID);
        List<Submission> GetProblemSubmissionsByAccountID(int problemID, int accoutID);
        List<Submission> GetProblemACSubmissions(int problemID);
        List<Submission> GetProblemACSubmissionsByAccountID(int problemID, int accountID);
    }
}