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
    public class FriendService : IFriendService
    {
        private IFriendDAO friendDAO;

        public FriendService()
        {
            friendDAO = new FriendDAO();
        }

        public void AddFriend(string friendUserId)
        {
            using (var context = new CineHiveContext())
            {
                friendDAO.AddFriend(friendUserId, context);
            }
        }
    }
}
