using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.SubmissionManagement
{
    public class SubmissionService: ISubmissionService
    {
        private readonly IRepository<Submission> _submissionRepo;
        public SubmissionService(IRepository<Submission> submissionRepo)
        {
            _submissionRepo = submissionRepo;
        }
        public List<Submission> GetProblemSubmissions(int problemID)
        {
            return _submissionRepo.GetAll().Where(p => p.problemID == problemID).ToList();
        }
        public List<Submission> GetProblemSubmissionsByAccountID(int problemID, int accountID)
        {
            return _submissionRepo.GetAll().Where(p => p.problemID == problemID && p.accountID == accountID).ToList();
        }
        public List<Submission> GetProblemACSubmissions(int problemID)
        {
            var problemSubmissions = this.GetProblemSubmissions(problemID);
            return problemSubmissions.Where(p => p.status == "Accepted").ToList();
        }
        public List<Submission> GetProblemACSubmissionsByAccountID(int problemID, int accountID)
        {
            var problemSubmissions = this.GetProblemSubmissionsByAccountID(problemID, accountID);
            return problemSubmissions.Where(p => p.status == "Accepted").ToList();
        }
    }
}