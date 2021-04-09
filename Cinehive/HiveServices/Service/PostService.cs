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

        public string PostContentToFilmLink(string input, Post post)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            string newInput = input.Trim();
            string query = "";
            int startC = 1; // first character of query
            int endC = 1; // last char of query
                          //check for film link if it contains '#'
            
            // loop input to find film link
            for (int i = 0; i < newInput.Length; i++)
            {
                if (newInput[i] == '#')
                {
                    post.hasFilmLink = true;

                    if ((i + 1) == newInput.Length) // check if # followed by characters
                    {
                        post.hasFilmLink = false;
                        startC = i;
                        break;
                    } 
                    else if (newInput[i+1] == ' ') // check if there is a query part of #
                    {
                        post.hasFilmLink = false;
                        break;
                    }
                    else
                    {
                        startC = i + 1; // first char of query is after #
                    }                  
                }
                else if (post.hasFilmLink == true && newInput[i] == ' ')
                {
                    endC = i - 1;
                    break;
                }
                else if (post.hasFilmLink == true && i == (newInput.Length - 1))
                {
                    endC = i;
                    break;
                }
            }
       
            if(!(bool)post.hasFilmLink)
            {
                return newInput;
            }

            // extract query after '#'
            for (int i = startC; i <= endC; i++)
            {
                query += newInput[i];
            }

            string finalOutput = newInput;
            if ((bool)post.hasFilmLink)
            {
                // if endC is also final char of string
                if (endC == (newInput.Length - 1))
                {
                    finalOutput += "</a>";
                }
                else
                {
                    finalOutput = newInput.Insert((endC + 1), "</a>"); // insert end of <a> tag
                }
                // insert start to contain #
                finalOutput = finalOutput.Insert((startC-1), "<a href='/Movie/GetPostMovie?query=" + query + "'>"); // insert start tag
            }

            return finalOutput;
        }

        public void DeletePost(int id)
        {
            using (var context = new CineHiveContext())
            {
                Post post = postDAO.GetPost(id, context);
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

        public IList<Post> GetCurrUserPosts()
        {
            using (var context = new CineHiveContext())
            {
                return postDAO.GetCurrUserPosts(context);
            }
        }

        public void EditPost(Post post)
        {
            using (var context = new CineHiveContext())
            {
                postDAO.EditPost(post, context);
            }
        }
        public void GiveAward(int id)
        {
            using (var context = new CineHiveContext())
            {
                postDAO.GiveAward(id, context);
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

            }
        }
    }
}
