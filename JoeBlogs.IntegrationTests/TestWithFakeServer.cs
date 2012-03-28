using System;
using NUnit.Framework;
using Nancy;
using Nancy.Hosting.Self;

namespace JoeBlogs.IntegrationTests
{
    public class TestWithFakeServer
    {
        private NancyHost fakeServer;
        protected WordPressWrapper wordpressWrapper;

        public TestWithFakeServer(string expectedMethod, string cannedResponse)
        {
            //  Gross injection for now until I learn how to load Nancy with
            //  only certain modules
            FakeWordPressServer.ExpectedMethod = expectedMethod;
            FakeWordPressServer.CannedResponse = cannedResponse;
        }

        [SetUp]
        public void Setup()
        {
            var uri = new Uri("http://localhost:8081/");
            fakeServer = new NancyHost(uri);
            fakeServer.Start();

            wordpressWrapper = new WordPressWrapper(uri.AbsoluteUri + "xmlrpc.php", FakeWordPressServer.Username, FakeWordPressServer.Password);
        }

        [TearDown]
        public void Cleanup()
        {
            if (fakeServer != null)
            {
                fakeServer.Stop();
                fakeServer = null;
            }
        }
    }
}