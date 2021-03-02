using HiveData.Repository;
using Cinehive.Models;
using HiveData.IDAO;
using HiveData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.DAO
{
    public class PostDAO : IPostDAO
    {
        public void CreatePost(Post post, CineHiveContext context)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void DeletePost(Post post, CineHiveContext context)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public Post GetPost(int id, CineHiveContext context)
        {
            return context.Posts.Find(id);
        }

        //public IList<Post> GetPosts(string id, CineHiveContext context)
        //{
        //    //UserProfile user = GetUser(id);
        //    //return user.Posts.ToList();
        //}
    }
}
