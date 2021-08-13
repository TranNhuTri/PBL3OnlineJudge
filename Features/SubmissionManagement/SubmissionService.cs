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
        public List<Submission> GetAllSubmissions()
        {
            return _submissionRepo.GetAll().ToList();
        }
        public List<Submission> GetAllSubmissionsByProblemID(int problemID)
        {
            return _submissionRepo.GetAll().Where(p => p.problemID == problemID).ToList();
        }
        public List<Submission> GetAllSubmissionsByAccountID(int accountID)
        {
            return _submissionRepo.GetAll().Where(p => p.accountID == accountID).ToList();
        }
        public List<Submission> GetSubmissionsByAccountProblemID(int accountID, int problemID, bool? AC)
        {
            return _submissionRepo.GetAll().Where(p => p.problemID == problemID && p.accountID == accountID
            && (AC == null || AC == true ? p.status == "Accepted" : p.status == "Wrong Answer")).ToList();
        }
        public void ChangeIsDeletedSubmissionsByProblemID(int problemID)
        {
            foreach(var item in this.GetAllSubmissionsByProblemID(problemID))
            {
                ChangeIsDeleted(item.ID);
            }
        }
        public void ChangeIsDeleted(int submissionID)
        {
            var submission = _submissionRepo.GetById(submissionID);
            submission.isDeleted = true;
            _submissionRepo.Update(submission);
            _submissionRepo.Save();
        }
        public Submission GetSubmissionByID(int submissionID)
        {
            return _submissionRepo.GetById(submissionID);
        }
        public void AddSubmission(Submission submission)
        {
            _submissionRepo.Insert(submission);
            _submissionRepo.Save();
        }
        public void UpdateSubmission(Submission submission)
        {
            _submissionRepo.Update(submission);
            _submissionRepo.Save();
        }
        public void DeleteSubmission(int submissionID)
        {
            _submissionRepo.Delete(submissionID);
            _submissionRepo.Save();
        }
    }
}