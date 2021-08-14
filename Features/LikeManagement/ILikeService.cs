using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.LikeManagement
{
    public interface ILikeService
    {
        List<Like> GetAllLikes();
        Like GetLikeByID(int LikeID);
        void AddLike(Like Like);
        void UpdateLike(Like Like);
        void ChangeStatusLike(int LikeID);
    }
}