using HiveData.Repository;
using Cinehive.Models;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.IDAO
{
    public interface IPostDAO
    {
        void CreatePost(string input, Post post, CineHiveContext context);
        void DeletePost(Post post, CineHiveContext context);
        Post GetPost(int id, CineHiveContext context);
        IList<Post> GetUserPosts(string userId, CineHiveContext context);
        void EditPost(Post post, CineHiveContext context);
        void GiveAward(int id, string userId, CineHiveContext context);
        void DeleteAssociatedComments(int id, CineHiveContext context);
        Award FindAward(int id, CineHiveContext context);
        void RevokeAward(int id, string userId, CineHiveContext context);

    }
}
