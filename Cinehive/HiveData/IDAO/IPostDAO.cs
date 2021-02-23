﻿using Cinehive.Models;
using HiveData.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.IDAO
{
    public interface IPostDAO
    {
        void CreatePost(Post post, ApplicationDbContext context);
    }
}
