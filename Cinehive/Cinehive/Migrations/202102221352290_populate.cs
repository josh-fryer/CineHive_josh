namespace Cinehive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using HiveData.Models.Domain;
    
    public partial class populate : DbMigration
    {
        public override void Up()
        {
            

            UserProfile userProfile1 = new UserProfile() { UserId = 1, Firstname = "Banana", Lastname = "Man", DateOfBirth = new DateTime(1992, 03, 22), Gender = "Male", FollowerCount = 102, FollowingCount = 112, AboutMe = "Movie lover, love the classics" };
            UserProfile userProfile2 = new UserProfile() { UserId = 2, Firstname = "Apple", Lastname = "Woman", DateOfBirth = new DateTime(1998, 10, 11), Gender = "Female", FollowerCount = 150, FollowingCount = 98, AboutMe = "Horror fanatic, I watch em all even the crap ones" };
            UserProfile userProfile3 = new UserProfile() { UserId = 3, Firstname = "Grape", Lastname = "Woman", DateOfBirth = new DateTime(1983, 07, 29), Gender = "Female", FollowerCount = 98, FollowingCount = 29, AboutMe = "All I do all day is watch tv series... I may have a problem" };
            UserProfile userProfile4 = new UserProfile() { UserId = 4, Firstname = "Melon", Lastname = "Man", DateOfBirth = new DateTime(1979, 01, 04), Gender = "Male", FollowerCount = 221, FollowingCount = 301, AboutMe = "Recommend me some good movies, £10 to anyone who can recommend one I haven't seen" };
            UserProfile userProfile5 = new UserProfile() { UserId = 5, Firstname = "Berry", Lastname = "Woman", DateOfBirth = new DateTime(1996, 12, 09), Gender = "Female", FollowerCount = 422, FollowingCount = 104, AboutMe = "Follow me for some great movie reviews!" };
      

            PostComment postComment1 = new PostComment() { UserId = 2, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Such a great movie!" };
            PostComment postComment2 = new PostComment() { UserId = 4, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Is it on Netflix?" };
            PostComment postComment3 = new PostComment() { UserId = 1, PostId = 2, DateCommented = (DateTime.Now), CommentContent = "Gotta love Leo" };
            PostComment postComment4 = new PostComment() { UserId = 3, PostId = 3, DateCommented = (DateTime.Now), CommentContent = "Now do it again in 4K" };
            PostComment postComment5 = new PostComment() { UserId = 5, PostId = 4, DateCommented = (DateTime.Now), CommentContent = "Its about time!" };
            

            Message message1 = new Message() { SenderId = 1, RecipientId = 2, MessageContent = "Hey, hows things been?", MessageSent = DateTime.Now };
            Message message2 = new Message() { SenderId = 2, RecipientId = 1, MessageContent = "Things are good, how're you?", MessageSent = DateTime.Now };
            Message message3 = new Message() { SenderId = 3, RecipientId = 2, MessageContent = "You wanna go to the cinema next week?", MessageSent = DateTime.Now };
            Message message4 = new Message() { SenderId = 5, RecipientId = 3, MessageContent = "u up?", MessageSent = DateTime.Now };
            Message message5 = new Message() { SenderId = 3, RecipientId = 1, MessageContent = "THAT was a terrible movie..", MessageSent = DateTime.Now };
            

            Follower follower1 = new Follower() { FollowerId = 1, FollowingId = 2, DateFollowed = DateTime.Now };
            Follower follower2 = new Follower() { FollowerId = 1, FollowingId = 3, DateFollowed = DateTime.Now };
            Follower follower3 = new Follower() { FollowerId = 2, FollowingId = 1, DateFollowed = DateTime.Now };
            Follower follower4 = new Follower() { FollowerId = 5, FollowingId = 4, DateFollowed = DateTime.Now };
            Follower follower5 = new Follower() { FollowerId = 4, FollowingId = 5, DateFollowed = DateTime.Now };
            

            Request request1 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 1, ReqSenderId = 2, ReqStatus = 0 };
            Request request2 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 3, ReqSenderId = 4, ReqStatus = 0 };
            Request request3 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 5, ReqSenderId = 1, ReqStatus = 0 };
            


        }

        public override void Down()
        {
        }
    }
}
