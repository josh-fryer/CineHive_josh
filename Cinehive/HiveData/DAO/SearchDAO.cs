using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.DAO
{
    public class SearchDAO : ISearchDAO
    {
        public async Task<List<Post>> SearchPostsAsync(string q, CineHiveContext context)
        {
            List<Post> postResults = new List<Post>();
            // search posts for query by latest first
            var orderedPosts = context.Posts.OrderByDescending(p => p.DatePosted).ToList();
            await Task.Run(() =>
            {
                for (int i = 0; i < orderedPosts.Count; i++)
                {
                    Post p = orderedPosts[i];
                    if (!String.IsNullOrEmpty(p.PostContent))
                    {
                        if (p.PostContent.Contains(q)) // case sensitive
                        {
                            postResults.Add(p);
                        }
                    }
                }
            });
            
            return postResults;
        }

        public async Task<List<UserProfile>> SearchUsersAsync(string q, CineHiveContext context)
        {
            return  context.UserProfiles.Where(x => x.Firstname.Contains(q) || x.Firstname.ToLower().Contains(q) ||
                        x.Firstname.ToUpper().Contains(q) || x.Lastname.Contains(q) || x.Lastname.ToLower().Contains(q)
                        || x.Lastname.ToUpper().Contains(q)).ToList();
        }
    }
}
