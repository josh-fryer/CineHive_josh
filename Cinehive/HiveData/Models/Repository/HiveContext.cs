using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models.Domain;
using System.Data.Entity;


namespace HiveData.Models.Repository
{
    public class HiveContext : DbContext
    {
        public HiveContext() : base("HiveContext")
        {
            Database.SetInitializer(new HiveInitialiser());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments {get; set;}
        public DbSet<Request> Requests { get; set; }

    }
}
