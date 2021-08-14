using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.CommentManagement
{
    public class CommentService: ICommentService
    {
        private readonly IRepository<Comment> _commentRepo;
        public CommentService(IRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public List<Comment> GetAllComments()
        {
            return _commentRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }

        public List<Comment> GetAllDeletedComments()
        {
            return _commentRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }

        public Comment GetCommentByID(int commentID)
        {
            return _commentRepo.GetById(commentID);
        }
        public List<Comment> GetCommentsByAccountID(int accountID)
        {
            return _commentRepo.GetAll().Where(p => p.accountID == accountID && p.isDeleted == false).ToList();
        }
        public List<Comment> GetCommentsByArticleID(int articleID)
        {
            return _commentRepo.GetAll().Where(p => p.isDeleted == false && p.postID == articleID && p.typePost == 2)
            .OrderByDescending(p => p.timeCreate).ToList();
        }
        public List<Comment> GetCommentsByProblemID(int problemID)
        {
            return _commentRepo.GetAll().Where(p => p.isHidden == false && p.isDeleted == false && p.postID == problemID && p.typePost == 1)
            .OrderByDescending(p => p.timeCreate).ToList();
        }
        public List<Comment> GetListCommentsByRootCommentID(int commetID)
        {
            return _commentRepo.GetAll().Where(p => p.rootCommentID == commetID && p.isDeleted == false && p.isHidden == false).ToList();
        }
        public void AddComment(Comment comment)
        {
            _commentRepo.Insert(comment);
            _commentRepo.Save();
        }
        public void UpdateComment(Comment comment)
        {
            _commentRepo.Update(comment);
            _commentRepo.Save();
        }
        public void ChangeIsDeletedComment(int commentID)
        {
            var comment = GetCommentByID(commentID);
            comment.isDeleted = !comment.isDeleted;
            _commentRepo.Save();
        }
    }
}