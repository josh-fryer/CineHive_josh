namespace Cinehive.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HiveData.Models.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<Cinehive.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cinehive.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            context.Messages.AddOrUpdate(
            new Message { SenderId = 1, RecipientId = 2, MessageContent = "Hey, hows things been?", MessageSent = DateTime.Now },
            new Message { SenderId = 2, RecipientId = 1, MessageContent = "Things are good, how're you?", MessageSent = DateTime.Now },
            new Message { SenderId = 3, RecipientId = 2, MessageContent = "You wanna go to the cinema next week?", MessageSent = DateTime.Now },
            new Message { SenderId = 5, RecipientId = 3, MessageContent = "u up?", MessageSent = DateTime.Now },
            new Message { SenderId = 3, RecipientId = 1, MessageContent = "THAT was a terrible movie..", MessageSent = DateTime.Now }
            );

            context.Followers.AddOrUpdate(
            new Follower { FollowerId = 1, FollowingId = 2, DateFollowed = DateTime.Now },
            new Follower { FollowerId = 1, FollowingId = 3, DateFollowed = DateTime.Now },
            new Follower { FollowerId = 2, FollowingId = 1, DateFollowed = DateTime.Now },
            new Follower { FollowerId = 5, FollowingId = 4, DateFollowed = DateTime.Now },
            new Follower { FollowerId = 4, FollowingId = 5, DateFollowed = DateTime.Now }
            );

            context.PostComments.AddOrUpdate(
            new PostComment { UserId = 2, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Such a great movie!" },
            new PostComment { UserId = 4, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Is it on Netflix?" },
            new PostComment { UserId = 1, PostId = 2, DateCommented = (DateTime.Now), CommentContent = "Gotta love Leo" },
            new PostComment { UserId = 3, PostId = 3, DateCommented = (DateTime.Now), CommentContent = "Now do it again in 4K" },
            new PostComment { UserId = 5, PostId = 4, DateCommented = (DateTime.Now), CommentContent = "Its about time!" }
            );

            context.Posts.AddOrUpdate(
            new Post { DatePosted = (DateTime.Now), UserId = 1, PostContent = "Everyone needs to go a watch Sunset Boulevard - Absolute classic!" },
            new Post { DatePosted = (DateTime.Now), UserId = 2, PostContent = "Great trip to the cinema to see Once upon a time in Hollywood, Leo is great in it" },
            new Post { DatePosted = (DateTime.Now), UserId = 3, PostContent = "Just finished all The Lord of the rings movies... Extended" },
            new Post { DatePosted = (DateTime.Now), UserId = 4, PostContent = "Bingewatching The Witcher" }
            );

            context.Requests.AddOrUpdate(
            new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 1, ReqSenderId = 2, ReqStatus = 0 },
            new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 3, ReqSenderId = 4, ReqStatus = 0 },
            new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 5, ReqSenderId = 1, ReqStatus = 0 }
            );

            context.UserProfiles.AddOrUpdate(
            new UserProfile { UserId = 1, Firstname = "Banana", Lastname = "Man", DateOfBirth = new DateTime(1992, 03, 22), Gender = "Male", FollowerCount = 102, FollowingCount = 112, AboutMe = "Movie lover, love the classics" },
            new UserProfile { UserId = 2, Firstname = "Apple", Lastname = "Woman", DateOfBirth = new DateTime(1998, 10, 11), Gender = "Female", FollowerCount = 150, FollowingCount = 98, AboutMe = "Horror fanatic, I watch em all even the crap ones" },
            new UserProfile { UserId = 3, Firstname = "Grape", Lastname = "Woman", DateOfBirth = new DateTime(1983, 07, 29), Gender = "Female", FollowerCount = 98, FollowingCount = 29, AboutMe = "All I do all day is watch tv series... I may have a problem" },
            new UserProfile { UserId = 4, Firstname = "Melon", Lastname = "Man", DateOfBirth = new DateTime(1979, 01, 04), Gender = "Male", FollowerCount = 221, FollowingCount = 301, AboutMe = "Recommend me some good movies, £10 to anyone who can recommend one I haven't seen" },
            new UserProfile { UserId = 5, Firstname = "Berry", Lastname = "Woman", DateOfBirth = new DateTime(1996, 12, 09), Gender = "Female", FollowerCount = 422, FollowingCount = 104, AboutMe = "Follow me for some great movie reviews!" }
            );

           

        }
    }
}
