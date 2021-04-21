using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.IService
{
    public interface IAdminService
    {
        void RemoveUserPosts(string id);
    }
}
