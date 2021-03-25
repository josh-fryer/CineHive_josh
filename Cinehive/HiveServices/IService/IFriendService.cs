using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.IService
{
    public interface IFriendService
    {
        void AddFriend(string friendId);
        void SendFriendReq(string friendId);
    }
}
