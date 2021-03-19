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
    public class AdminDAO : IAdminDAO
    {
        public void BanUser(string id, CineHiveContext context)
        {
            // set users role to banned
        }
    }
}
