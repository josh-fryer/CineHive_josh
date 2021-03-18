using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;
namespace HiveData.ViewModels
{
    public class ProfilePostsViewModel
    {
        public UserProfile userProfile { get; set; }
        public ICollection<Post> Posts { get; set; }

    }



}
