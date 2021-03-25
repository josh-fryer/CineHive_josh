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
        void AddFriend(string friendId, CineHiveContext context);
        void SendFriendReq(string friendId, CineHiveContext context);
    }
}
