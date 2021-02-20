using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HiveData.Models.Domain;

namespace HiveData.Models.Repository
{
    public class HiveInitialiser : DropCreateDatabaseIfModelChanges<HiveContext>
    {
        protected override void Seed(HiveContext context)
        {
            User User1 = new User() { Email = "banana@live.com", Password = "banana", DateCreated = (DateTime.Now), IsRestricted = false, IsVerified = true};
            User User2 = new User() { Email = "apple@live.com", Password = "apple", DateCreated = (DateTime.Now), IsRestricted = false, IsVerified = true };
            User User3 = new User() { Email = "grape@live.com", Password = "grape", DateCreated = (DateTime.Now), IsRestricted = false, IsVerified = true };
            User User4 = new User() { Email = "melon@live.com", Password = "melon", DateCreated = (DateTime.Now), IsRestricted = false, IsVerified = true };
            User User5 = new User() { Email = "berry@live.com", Password = "berry", DateCreated = (DateTime.Now), IsRestricted = false, IsVerified = true };
            context.Users.Add(User1); context.Users.Add(User2); context.Users.Add(User3); context.Users.Add(User4); context.Users.Add(User5);

            UserProfile userProfile1 = new UserProfile() { UserId = 1, Firstname = "Banana", Lastname = "Man", DateOfBirth = new DateTime(1992, 03, 22), Gender = "Male", FollowerCount = 102, FollowingCount = 112, AboutMe = "Movie lover, love the classics" };
            UserProfile userProfile2 = new UserProfile() { UserId = 2, Firstname = "Apple", Lastname = "Woman", DateOfBirth = new DateTime(1998, 10, 11), Gender = "Female", FollowerCount = 150, FollowingCount = 98, AboutMe = "Horror fanatic, I watch em all even the crap ones" };
            UserProfile userProfile3 = new UserProfile() { UserId = 3, Firstname = "Grape", Lastname = "Woman", DateOfBirth = new DateTime(1983, 07, 29), Gender = "Female", FollowerCount = 98, FollowingCount = 29, AboutMe = "All I do all day is watch tv series... I may have a problem" };
            UserProfile userProfile4 = new UserProfile() { UserId = 4, Firstname = "Melon", Lastname = "Man", DateOfBirth = new DateTime(1979, 01, 04), Gender = "Male", FollowerCount = 221, FollowingCount = 301, AboutMe = "Recommend me some good movies, £10 to anyone who can recommend one I haven't seen"};
            UserProfile userProfile5 = new UserProfile() { UserId = 5, Firstname = "Berry", Lastname = "Woman", DateOfBirth = new DateTime(1996, 12, 09), Gender = "Female", FollowerCount = 422, FollowingCount = 104, AboutMe = "Follow me for some great movie reviews!" };
            context.UserProfiles.Add(userProfile1); context.UserProfiles.Add(userProfile2); context.UserProfiles.Add(userProfile3); context.UserProfiles.Add(userProfile4); context.UserProfiles.Add(userProfile5);

            Post post1 = new Post() { DatePosted = (DateTime.Now), UserId = 1, PostContent = "Everyone needs to go a watch Sunset Boulevard - Absolute classic!" };
            Post post2 = new Post() { DatePosted = (DateTime.Now), UserId = 2, PostContent = "Great trip to the cinema to see Once upon a time in Hollywood, Leo is great in it" };
            Post post3 = new Post() { DatePosted = (DateTime.Now), UserId = 3, PostContent = "Just finished all The Lord of the rings movies... Extended" };
            Post post4 = new Post() { DatePosted = (DateTime.Now), UserId = 4, PostContent = "Bingewatching The Witcher"};
            context.Posts.Add(post1); context.Posts.Add(post2); context.Posts.Add(post3); context.Posts.Add(post4);

            PostComment postComment1 = new PostComment() { UserId = 2, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Such a great movie!" };
            PostComment postComment2 = new PostComment() { UserId = 4, PostId = 1, DateCommented = (DateTime.Now), CommentContent = "Is it on Netflix?" };
            PostComment postComment3 = new PostComment() { UserId = 1, PostId = 2, DateCommented = (DateTime.Now), CommentContent = "Gotta love Leo" };
            PostComment postComment4 = new PostComment() { UserId = 3, PostId = 3, DateCommented = (DateTime.Now), CommentContent = "Now do it again in 4K" };
            PostComment postComment5 = new PostComment() { UserId = 5, PostId = 4, DateCommented = (DateTime.Now), CommentContent = "Its about time!" };
            context.PostComments.Add(postComment1); context.PostComments.Add(postComment2); context.PostComments.Add(postComment3); context.PostComments.Add(postComment4); context.PostComments.Add(postComment5);

            Message message1 = new Message() { SenderId = 1, RecipientId = 2, MessageContent = "Hey, hows things been?", MessageSent = DateTime.Now };
            Message message2 = new Message() { SenderId = 2, RecipientId = 1, MessageContent = "Things are good, how're you?", MessageSent = DateTime.Now };
            Message message3 = new Message() { SenderId = 3, RecipientId = 2, MessageContent = "You wanna go to the cinema next week?", MessageSent = DateTime.Now };
            Message message4 = new Message() { SenderId = 5, RecipientId = 3, MessageContent = "u up?", MessageSent = DateTime.Now };
            Message message5 = new Message() { SenderId = 3, RecipientId = 1, MessageContent = "THAT was a terrible movie..", MessageSent = DateTime.Now };
            context.Messages.Add(message1); context.Messages.Add(message2); context.Messages.Add(message3); context.Messages.Add(message4); context.Messages.Add(message5);

            Follower follower1 = new Follower() { FollowerId = 1, FollowingId = 2, DateFollowed = DateTime.Now };
            Follower follower2 = new Follower() { FollowerId = 1, FollowingId = 3, DateFollowed = DateTime.Now };
            Follower follower3 = new Follower() { FollowerId = 2, FollowingId = 1, DateFollowed = DateTime.Now };
            Follower follower4 = new Follower() { FollowerId = 5, FollowingId = 4, DateFollowed = DateTime.Now };
            Follower follower5 = new Follower() { FollowerId = 4, FollowingId = 5, DateFollowed = DateTime.Now };
            context.Followers.Add(follower1); context.Followers.Add(follower2); context.Followers.Add(follower3); context.Followers.Add(follower4); context.Followers.Add(follower5);

            Request request1 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 1, ReqSenderId = 2, ReqStatus = 0 };
            Request request2 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 3, ReqSenderId = 4, ReqStatus = 0 };
            Request request3 = new Request() { ReqDateSent = DateTime.Now, ReqRecipientId = 5, ReqSenderId = 1, ReqStatus = 0 };
            context.Requests.Add(request1); context.Requests.Add(request2); context.Requests.Add(request3);




            context.SaveChanges();
            
            
        }
    }
}
