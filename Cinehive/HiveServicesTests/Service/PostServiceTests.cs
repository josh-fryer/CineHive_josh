using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiveServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveServices.Service.Tests
{
    [TestClass()]
    public class PostServiceTests
    {
        //[TestMethod()]
        //public void PostContentToFilmLink_FullFilmLink_ReturnsStringWithHtml()
        //{
        //    // arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#TheLordOfTheRings";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    Assert.AreEqual("<a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a>", result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_OnlyHashTag_ReturnsStringNoHtml()
        //{
        //    // arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    Assert.AreEqual("#", result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_PostWithHashtagNoQuery_ReturnsSameStringNoHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "This post # contains no html";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    string expected = input;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_PostWithHashtagEnd_ReturnsStringWithHtml()
        //{
        //    // arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "this film is so cool #TheLordOfTheRings";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    string expected = "this film is so cool <a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a>";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_PostWithHashtagMiddle_ReturnsStringWithHtml()
        //{
        //    // arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "this film #TheLordOfTheRings is so cool";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    string expected = "this film <a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a> is so cool";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_PostWithHashtagStart_ReturnsStringWithHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#TheLordOfTheRings this film is so cool";

        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);

        //    // Assert
        //    string expected = "<a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a> this film is so cool";
        //    Assert.AreEqual(expected, result);
        //}

        //// ######## With Year Filter ##########
        //[TestMethod()]
        //public void PostContentToFilmLink_FilmWithYearFilter_ReturnsStringWithHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#TheLordOfTheRings/2001";
        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);
        //    // Assert
        //    string expected = "<a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings&year=2001'>#TheLordOfTheRings</a>";
        //    Assert.AreEqual(expected, result);
        //}
        
        //[TestMethod()]
        //public void PostContentToFilmLink_FilmWithIncompleteYear1_ReturnsOnlyTitleInHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#TheLordOfTheRings/20";
        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);
        //    // Assert
        //    string expected = "<a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a>/20";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_FilmWithIncompleteYear2_ReturnsStringWithHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "#TheLordOfTheRings/";
        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);
        //    // Assert
        //    string expected = "<a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings'>#TheLordOfTheRings</a>/";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_FilmWithYear3_ReturnsStringWithHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "Whoa so cool #TheLordOfTheRings/2001";
        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);
        //    // Assert
        //    string expected = "Whoa so cool <a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings&year=2001'>#TheLordOfTheRings</a>";
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod()]
        //public void PostContentToFilmLink_FilmWithYear4_ReturnsStringWithHtml()
        //{
        //    // Arrange
        //    var postService = new PostService();
        //    var post = new Post();
        //    string input = "Whoa so cool #TheLordOfTheRings/2001 amazing";
        //    // Act
        //    var result = postService.PostContentToFilmLink(input, post);
        //    // Assert
        //    string expected = "Whoa so cool <a href='/Movie/GetPostMovie?query=The+Lord+Of+The+Rings&year=2001'>#TheLordOfTheRings</a> amazing";
        //    Assert.AreEqual(expected, result);
        //}
    }
}