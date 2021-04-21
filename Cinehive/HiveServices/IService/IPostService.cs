using HiveData.Repository;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.IService
{
    public interface IPostService
    {
        void CreatePost(string input, Post post);
        void DeletePost(int id);
        Post GetPost(int id);
        IList<Post> GetUserPosts(string userId);
        void EditPost(Post post);
        void GiveAward(int id, string userId);
        void DeleteAssociatedComments(int id);
        Award FindAward(int id);
        void SharePost(int id, string userID);
        void RevokeAward(int id, string userId);
    }
}
