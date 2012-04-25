using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using Newtonsoft.Json;

namespace JoeBlogs.Console
{
    public class DumpCategories : ConsoleCommand
    {
        public DumpCategories()
        {
            this.IsCommand("dump-categories", "Writes categories in JSON.");
            LoginInfo.AddXmlRpcLogin(this);
            this.SkipsCommandSummaryBeforeRunning();
        }

        public LoginInfo LoginInfo = new LoginInfo();
 
        public override int Run(string[] remainingArguments)
        {
            var client = LoginInfo.GetWordPressClient();

            var results = client.GetCategories();

            System.Console.WriteLine(JsonConvert.SerializeObject(results,Formatting.Indented));

            return 0;
        }
    }
}
