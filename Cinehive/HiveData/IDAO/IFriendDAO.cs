using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.IDAO
{
    public interface IFriendDAO
    {
        void AddFriend(string userId, string friendId, CineHiveContext context);
        void SendFriendReq(string userId, string friendId, CineHiveContext context);
        void RemoveFriend(string friendId, string userId, CineHiveContext context);
    }
}
