using HiveData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveData.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
