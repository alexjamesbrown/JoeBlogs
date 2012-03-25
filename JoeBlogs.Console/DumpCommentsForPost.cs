using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using Newtonsoft.Json;

namespace JoeBlogs.Console
{
    public class DumpCommentsForPost : ConsoleCommand
    {
        public DumpCommentsForPost()
        {
            this.IsCommand("dump-comments", "Dumps the comments for a WordPress post in JSON.");
            LoginInfo.AddXmlRpcLogin(this);
            this.HasRequiredOption("postid=", "The post id to load comments for.", v => PostId = Int32.Parse(v));
        }

        public LoginInfo LoginInfo = new LoginInfo();
        public int PostId;

        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            var posts = new List<Comment>();

            var statuses = client.GetCommentStatusList(PostId.ToString());

            foreach(var status in statuses)
            {
                posts.AddRange(client.GetComments(PostId, status, 1, 0));
            }

            System.Console.WriteLine(JsonConvert.SerializeObject(posts.OrderBy(p => p.DateCreated), Formatting.Indented));

            return 0;
        }
    }
}
