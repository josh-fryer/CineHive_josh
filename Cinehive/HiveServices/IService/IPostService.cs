﻿using HiveData.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.IService
{
    public interface IPostService
    {
        void CreatePost(Post post, string userId);
    }
}
