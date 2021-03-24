using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveServices.IService
{
    public interface ICommentService
    {
        PostComment GetComment(int id);
        void EditComment(PostComment postComment);
        void DeleteComment(int id);
    }
}
