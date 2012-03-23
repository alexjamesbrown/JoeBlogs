using ManyConsole;

namespace JoeBlogs.Console
{
    public class LoginInfo
    {
        public string XmlRpcUrl = "http://joeblogstest.alexjamesbrown.com/xmlrpc.php";
        public string Username = "joeblogs";
        public string Password = "joeblogs123";

        public void AddXmlRpcLogin(ConsoleCommand command)
        {
            command.HasOption("rpc=",
                              "Url of wordpress XML-RPC endpoint (example: http://joeblogstest.alexjamesbrown.com/xmlrpc.php)",
                              v => XmlRpcUrl = v);
            command.HasOption("u=", "Username", v => Username = v);
            command.HasOption("p=", "Password", v => Password = v);
        }

        public WordPressWrapper GetWordPressClient()
        {
            //remember to include the http://
            string Url = XmlRpcUrl; //change this to the location of your xmlrpc.php file
            //typically http://www.yourdomain.com/xmlrpc.php (if your wordpress blog is installed in root dir)
            var result = new WordPressWrapper(XmlRpcUrl, Username, Password);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", XmlRpcUrl, Username, Password);
        }
    }
}