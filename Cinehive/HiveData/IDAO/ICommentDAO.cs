﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.IDAO
{
    public interface ICommentDAO
    {
        PostComment GetComment(int id, CineHiveContext context);
        void EditComment(PostComment postComment, CineHiveContext context);
        void DeleteComment(PostComment postComment, CineHiveContext context);
    }
}
