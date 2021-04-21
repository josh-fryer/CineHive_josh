using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Repository;
using HiveServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public class AdminService : IAdminService
    {
        private IPostDAO postDAO;

        public AdminService()
        {
            postDAO = new PostDAO();
        }

        public void RemoveUserPosts(string id)
        {
            using (var context = new CineHiveContext())
            {
                // get posts
                var postList = postDAO.GetUserPosts(id, context);
                // Delete posts
                context.Posts.RemoveRange(postList);
                context.SaveChanges();
                
            }
        }

        
    }
}
