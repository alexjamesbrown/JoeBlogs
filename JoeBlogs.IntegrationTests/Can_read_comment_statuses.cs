using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Nancy;
using Nancy.Hosting.Self;
using NUnit.Framework;

namespace JoeBlogs.IntegrationTests
{
    [TestFixture]
    public class Can_read_comment_statuses
    {
        private NancyHost fakeServer;

        [TearDown]
        public void Cleanup()
        {
            if (fakeServer != null)
            {
                fakeServer.Stop();
                fakeServer = null;
            }
        }

        [Test]
        public void Should__read_list_of_comments()
        {
            var uri = new Uri ("http://localhost:8080/");
            NancyHost fakeServer = new NancyHost(uri);
            fakeServer.Start();

            var wordpressWrapper = new WordPressWrapper(uri.AbsoluteUri + "xmlrpc.php", FakeWordPressServer.Username, FakeWordPressServer.Password);

            var results = wordpressWrapper.GetCommentStatusList("1");

            Assert.That(results, Is.EqualTo(new [] {"Unapproved", "Approved", "Spam"}));
        }

        public class FakeWordPressServer : NancyModule
        {
            public const string Username = "Administrator";
            public const string Password = "Password";
            public const int PostId = 1;

            public FakeWordPressServer()
            {
                Post["/xmlrpc.php"] = x =>
                {
                    var doc = XDocument.Load(this.Request.Body);

                    var root = doc.Root;
                    Assert.That(root.Element("methodName").Value, Is.EqualTo("wp.getCommentStatusList"));

                    this.Response.Context.Parameters["content-type"] = "text.xml";
                    return
                        @"<?xml version=""1.0""?>
<methodResponse>
  <params>
    <param>
      <value>
      <struct>
  <member><name>hold</name><value><string>Unapproved</string></value></member>
  <member><name>approve</name><value><string>Approved</string></value></member>
  <member><name>spam</name><value><string>Spam</string></value></member>
</struct>
      </value>
    </param>
  </params>
</methodResponse>
";
                };
            }
        }
    }
}
