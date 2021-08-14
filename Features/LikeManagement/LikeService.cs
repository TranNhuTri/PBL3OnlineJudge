using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.LikeManagement
{
    public class LikeService: ILikeService
    {
        private readonly IRepository<Like> _likeRepo;
        public LikeService(IRepository<Like> likeRepo)
        {
            _likeRepo = likeRepo;
        }
        public List<Like> GetAllLikes()
        {
            return _likeRepo.GetAll().ToList();
        }
        public List<Like> GetLikesByCommentID(int commentID)
        {
            return _likeRepo.GetAll().Where(p => p.commentID == commentID && p.status == true).ToList();
        }
        public Like GetLikeByID(int likeID)
        {
            return _likeRepo.GetById(likeID);
        }
        public void AddLike(Like like)
        {
            _likeRepo.Insert(like);
            _likeRepo.Save();
        }
        public void UpdateLike(Like like)
        {
            _likeRepo.Update(like);
            _likeRepo.Save();
        }
        public void ChangeStatusLike(int likeID)
        {
            var like = GetLikeByID(likeID);
            like.status = !like.status;
            _likeRepo.Save();
        }
    }
}