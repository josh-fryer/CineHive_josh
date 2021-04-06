using HiveData.Models;
using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.IDAO
{
    public interface ISearchDAO
    {
        Task<List<Post>> SearchPostsAsync(string q, CineHiveContext context);
        Task<List<UserProfile>> SearchUsersAsync(string q, CineHiveContext context);
    }
}
