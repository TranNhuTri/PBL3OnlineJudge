using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.CommentManagement
{
    public interface ICommentService
    {
        List<Comment> GetAllComments();
        List<Comment> GetAllDeletedComments();
        Comment GetCommentByID(int commentID);
        List<Comment> GetCommentsByArticleID(int articleID);
        List<Comment> GetCommentsByProblemID(int problemID);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentID);
        void ChangeIsDeletedComment(int commentID);
    }
}