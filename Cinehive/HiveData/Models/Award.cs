﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Award
    {
        [Key]
        public int AwardId { get; set; }
        public int PostId { get; set; }

    }
}
