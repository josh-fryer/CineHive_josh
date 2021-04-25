using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using HiveServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;

namespace HiveServices.Service
{
    public class PostService : IPostService
    {
        private IPostDAO postDAO;

        public PostService()
        {
            postDAO = new PostDAO();
        }

        public void CreatePost(string input, Post post)
        {
            using (var context = new CineHiveContext())
            {
                string newInput = PostContentToFilmLink(input, post);

                postDAO.CreatePost(newInput, post, context);
                context.SaveChanges();
            }
        }

        // convert #filmlinks to link with inserted html
        public string PostContentToFilmLink(string input, Post post)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            string newInput = input.Trim();
            string query = "";
            string year = "";
            bool hasYear = false;

            int startC = 1; // first character of query
            int endC = 1; // last char of query                        

            // loop input to find film link
            for (int i = 0; i < newInput.Length; i++)
            {
                if (newInput[i] == '#')
                {
                    post.hasFilmLink = true;

                    if ((i + 1) == newInput.Length) // check if # followed by characters
                    {
                        post.hasFilmLink = false;
                        break;
                    }
                    else if (newInput[i + 1] == ' ') // check if there is a char after #
                    {
                        post.hasFilmLink = false;
                        break;
                    }
                    else
                    {
                        startC = i + 1; // first char of query is after #
                    }
                }
                else if (post.hasFilmLink == true && newInput[i] == ' ') // check if reached end of film title link
                {
                    endC = i - 1;
                    break;
                }
                else if (newInput[i] == '/' && post.hasFilmLink == true) // found start of year filter
                {
                    endC = i - 1;
                    if (i + 4 < newInput.Length) // if there are 4 chars following '/'
                    {
                        hasYear = true; // confirmed with loop below
                        // loop to add char to year
                        for (int j = (i + 1); j < (i + 5); j++)
                        {
                            if (Char.IsDigit(newInput[j]))
                            {
                                year += newInput[j];
                            }
                            else
                            {
                                hasYear = false;
                                break;
                            }
                        }
                        break;
                    }
                    else { hasYear = false; break; }
                }
                else if (post.hasFilmLink == true && i == (newInput.Length - 1)) // if at end of post content
                {
                    endC = i;
                    break;
                }
            }

            if (!post.hasFilmLink)
            {
                return newInput;
            }

            // extract film title query after '#'
            for (int i = startC; i <= endC; i++)
            {
                char c = input[i];
                if ((i + 1) <= endC) // if next character is not outside index
                {
                    if (Char.IsUpper(input[i + 1]) || Char.IsDigit(input[i + 1])) // find new separate word if its Caps or a number
                    {
                        query += c;
                        query += '+';
                    }
                    else
                    {
                        query += c;
                    }
                }
                else
                {
                    query += c;
                }
            }

            string finalOutput = newInput;
            if (post.hasFilmLink)
            {
                //---- 1. Insert end of link tag -----
                // if endC is also final char of string
                if (endC == (newInput.Length - 1))
                {
                    finalOutput += "</a>";
                }
                else
                {
                    if (hasYear)
                    {
                        // remove year
                        newInput = newInput.Remove(endC + 1, 5);
                    }
                    finalOutput = newInput.Insert((endC + 1), "</a>"); // insert end of <a> tag
                }

                //---- 2. Insert start of link tag -----
                if (hasYear)
                {
                    finalOutput = finalOutput.Insert((startC - 1), "<a href='/Movie/GetPostMovie?query=" + query + "&year=" + year + "'>"); // insert start tag
                }
                else
                {
                    finalOutput = finalOutput.Insert((startC - 1), "<a href='/Movie/GetPostMovie?query=" + query + "'>"); // insert start tag
                }
            }

            return finalOutput;
        }

        public void DeletePost(int id)
        {
            using (var context = new CineHiveContext())
            {
                Post post = postDAO.GetPost(id, context);
                postDAO.DeleteAssociatedComments(id, context);
                postDAO.DeletePost(post, context);
            }
        }

        public Post GetPost(int id)
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.GetPost(id, context);
            }
        }

        public IList<Post> GetUserPosts(string userId)
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.GetUserPosts(userId ,context);
            }
        }

        public void EditPost(Post post)
        {
            using (var context = new CineHiveContext())
            {
                postDAO.EditPost(post, context);
            }
        }

        public void GiveAward(int id, string userId)
        {
            using (var context = new CineHiveContext())
            {
                postDAO.GiveAward(id, userId, context);
                context.SaveChanges();
            }
        }

        public void RevokeAward(int id, string userId)
        {
            using(var context = new CineHiveContext())
            {               
                postDAO.RevokeAward(id, userId, context);
                context.SaveChanges();           
            }
        }

        public Award FindAward(int id)
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.FindAward(id, context);
            }
        }

        public void DeleteAssociatedComments(int id)
        {
            using (var context = new CineHiveContext())
            {                
                postDAO.DeleteAssociatedComments(id, context);
                context.SaveChanges();
            }
        }

        public void SharePost(int id, string userID)
        {
            using (var context = new CineHiveContext())
            {
                Post post = postDAO.GetPost(id, context); // the post to share
                // get post profile
                //var authorProfile = context.UserProfiles.First(i => i.Posts.Contains(post));

                Post post1 = new Post()
                {             
                    DatePosted = DateTime.Now,
                    AuthorPost = post,
                    Shared = true
                };

                
                UserProfile profile = context.UserProfiles.First(x => x.UserId == userID);
                profile.Posts.Add(post1);
                context.SaveChanges();
            }
        }
    }
}
