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
            this.HasOption("raw", "Include more of the original fields, in raw format.", v => UseRawFormat = true);
            this.SkipsCommandSummaryBeforeRunning();
        }

        public LoginInfo LoginInfo = new LoginInfo();
        public int PostId;
        public bool UseRawFormat;

        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            object post = null;

            if (UseRawFormat)
                post = client.GetPostRaw(PostId);
            else
                post = client.GetPost(PostId);

            System.Console.WriteLine(JsonConvert.SerializeObject(post, Formatting.Indented));

            return 0;
        }
    }
}
