using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using Newtonsoft.Json;

namespace JoeBlogs.Console
{
    public class DumpTags : ConsoleCommand
    {
        public DumpTags()
        {
            this.IsCommand("dump-tags", "Writes tags for a blog in json.");
            LoginInfo.AddXmlRpcLogin(this);
            this.SkipsCommandSummaryBeforeRunning();
        }

        public LoginInfo LoginInfo = new LoginInfo();

        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            var results = client.GetTags();

            System.Console.WriteLine(JsonConvert.SerializeObject(results, Formatting.Indented));

            return 0;
        }
    }
}
