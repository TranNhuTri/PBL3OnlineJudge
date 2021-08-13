using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.SubmissionManagement
{
    public interface ISubmissionService
    {
        List<Submission> GetAllSubmissions();
        List<Submission> GetAllSubmissionsByProblemID(int problemID);
        List<Submission> GetAllSubmissionsByAccountID(int accountID);
        List<Submission> GetSubmissionsByAccountProblemID(int accountID, int problemID, bool? AC);
        Submission GetSubmissionByID(int submissionID);
        void AddSubmission(Submission submission);
        void UpdateSubmission(Submission submission);
        void DeleteSubmission(int submissionID);
    }
}