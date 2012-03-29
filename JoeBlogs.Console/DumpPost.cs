using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using Newtonsoft.Json;

namespace JoeBlogs.Console
{
    public class DumpPost : ConsoleCommand
    {
        public DumpPost()
        {
            this.IsCommand("dump-post", "Writes a WordPress post in json.");
            LoginInfo.AddXmlRpcLogin(this);
            this.HasRequiredOption("postid=", "The post id to load comments for.", v => PostId = Int32.Parse(v));
            this.SkipsCommandSummaryBeforeRunning();
        }

        public LoginInfo LoginInfo = new LoginInfo();
        public int PostId;

        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            var post = client.GetPost(PostId);

            System.Console.WriteLine(JsonConvert.SerializeObject(post));

            return 0;
        }
    }
}
