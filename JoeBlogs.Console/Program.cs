using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoeBlogs.Console
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var commands = ManyConsole.ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
            return ManyConsole.ConsoleCommandDispatcher.DispatchCommand(commands, args, System.Console.Out);
        }
    }
}
