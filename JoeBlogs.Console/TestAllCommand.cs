using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using JoeBlogs;

namespace JoeBlogs.Console
{
    public class TestAllCommand : ConsoleCommand
    {
        public TestAllCommand()
        {
            this.IsCommand("test-all", "Tests all the things.");
        }

        static JoeBlogs.IWordPressWrapper _wpWrapper;

        public override int Run(string[] remainingArguments)
        {
            //remember to include the http://
            string Url = "http://joeblogstest.alexjamesbrown.com/xmlrpc.php"; //change this to the location of your xmlrpc.php file
            //typically http://www.yourdomain.com/xmlrpc.php (if your wordpress blog is installed in root dir)

            string User = "joeblogs"; //enter your username
            string Password = "joeblogs123"; //enter your password

            _wpWrapper = new WordPressWrapper(Url, User, Password);

            #region Posts
            //create a new post
            var newPostID = createNewPost();

            //edit the post created above
            editPost(newPostID);

            //delete post created above
            _wpWrapper.DeletePost(newPostID);

            //get list of post status'
            var statusList = _wpWrapper.GetPostStatusList();
            #endregion

            #region Authors
            _wpWrapper.GetAuthors();
            #endregion

            #region Pages
            //create new page
            var newpageID = createPage();

            //get list of pages
            var pageList = _wpWrapper.GetPageList();

            //delete page
            var pageHasBeenDeleted = _wpWrapper.DeletePage(newpageID);

            //get page (using the ID from the page created above)
            var page = _wpWrapper.GetPage(newpageID);

            //todo: edit page
            #endregion

            #region Category

            //create a category
            var description = "This is a test description";
            var name = "Alex Cat";
            var slug = "testSlug";

            var catID = _wpWrapper.NewCategory(description, null, name, slug);

            var cats = _wpWrapper.GetCategories();

            var deletedCat = _wpWrapper.DeleteCategory(catID);
            #endregion

            #region Comments
            //create a new post
            var newPostForComment = createNewPost();

            var authorEmail = "alex@test.com";
            var authorName = "Joe Blogs";
            var content = "This is a bit of text for the comment";
            var authorUrl = "www.alexjamesbrown.com";

            //add a comment to this post
            _wpWrapper.NewComment(newPostForComment, null, content, authorName, authorUrl, authorEmail);
            #endregion

            return 0;
        }

        private static string createPage()
        {
            var page = new Page
            {
                AllowComments = false,
                AllowPings = false,
                AuthorID = 1,
                Body = "This is some test text This is some test text This is some test text This is some test text This is some test text ",
                Title = "Test Page"
            };

            var newpageID = _wpWrapper.NewPage(page, true);
            return newpageID;
        }

        private static int createNewPost()
        {
            var post = new Post()
            {
                Body = "This is a test body",
                Categories = new string[] { "1", "2", "3" },
                Tags = new string[] { "tag one", "another tag", "one more" },
                Title = "Test post",
            };

            return _wpWrapper.NewPost(post, true);
        }
        private static void editPost(int newPostID)
        {
            var post = _wpWrapper.GetPost(newPostID);

            post.Body = "Just edited the body";
            post.Categories = new string[] { "14" };
            post.Tags = new string[] { "new keyword" };
            post.Title = "Changed the title";

            _wpWrapper.EditPost(newPostID, post, true);
        }
    }
}
