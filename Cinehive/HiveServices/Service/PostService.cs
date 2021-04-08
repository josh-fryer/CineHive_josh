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

                if (newInput == null)
                {
                    newInput = input;
                }

                postDAO.CreatePost(newInput, post, context);
                context.SaveChanges();
            }
        }

        private static string PostContentToFilmLink(string input, Post post)
        {
            string newInput = input;
            string query = "";
            int startC = 1; // first character of query
            int endC = 1; // last char of query
                          //check for film link if it contains '#'
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '#')
                    {
                        post.hasFilmLink = true;
                        startC = i + 1;
                    }
                    else if (post.hasFilmLink == true && input[i] == ' ')
                    {
                        endC = i - 1;
                        break;
                    }
                    else if (post.hasFilmLink == true && i == (input.Length - 1))
                    {
                        endC = i;
                        break;
                    }
                }
            }
            else { return input; }

            if(!(bool)post.hasFilmLink)
            {
                return null;
            }

            // extract query after '#'
            for (int i = startC; i <= endC; i++)
            {
                query += input[i];
            }

            if ((bool)post.hasFilmLink)
            {

                // if endC is also final char of string
                if (endC == (input.Length - 1))
                {
                    newInput += "</a>";
                }
                else
                {
                    newInput = input.Insert((endC + 1), "</a>"); // insert end of <a> tag
                }
                newInput = newInput.Insert(startC, "<a href='/Movie/GetPostMovie?query=" + query + "'>"); // insert start tag
            }

            return newInput;
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
