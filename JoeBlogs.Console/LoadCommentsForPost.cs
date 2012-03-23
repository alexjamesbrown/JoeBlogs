using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;

namespace JoeBlogs.Console
{
    public class LoadCommentsForPost : ConsoleCommand
    {
        public LoadCommentsForPost()
        {
            this.IsCommand("load-comments", "Loads the comments for a WordPress post.");
            LoginInfo.AddXmlRpcLogin(this);
            this.HasRequiredOption("postid=", "The post id to load comments for.", v => PostId = Int32.Parse(v));
        }

        public LoginInfo LoginInfo = new LoginInfo();
        public int PostId;

        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            var posts = new List<Comment>();

            foreach(var verb in new [] { "Approved", "approved", "published", "Published"})
            {
                posts.AddRange(client.GetComments(PostId, verb, 1, 0));
            }
                

            foreach(var post in posts)
            {
                System.Console.WriteLine(
                    "Has post: " + post.PostTitle);
            }

            return 0;
        }
    }
}
