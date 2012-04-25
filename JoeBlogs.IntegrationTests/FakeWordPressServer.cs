using System.Xml.Linq;
using NUnit.Framework;
using Nancy;

namespace JoeBlogs.IntegrationTests
{
    public class FakeWordPressServer : NancyModule
    {
        public static string ExpectedMethod;
        public static string CannedResponse;
        public const string Username = "Administrator";
        public const string Password = "Password";

        public FakeWordPressServer()
        {
            Post["/xmlrpc.php"] = x =>
                {
                    var doc = XDocument.Load(this.Request.Body);

                    var root = doc.Root;
                    Assert.That(root.Element("methodName").Value, Is.EqualTo(ExpectedMethod));

                    this.Response.Context.Parameters["content-type"] = "text.xml";
                    return CannedResponse;
                };
        }
    }
}