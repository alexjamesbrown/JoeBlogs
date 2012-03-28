using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoeBlogs.IntegrationTests
{
    [TestFixture]
    public class Can_read_comment_statuses : TestWithFakeServer
    {
        public Can_read_comment_statuses()
            : base("wp.getCommentStatusList", @"<?xml version=""1.0""?>
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
")
        {
        }

        [Test]
        public void Should__read_list_of_comments()
        {
            var results = wordpressWrapper.GetCommentStatusList("1");

            Assert.That(results, Is.EqualTo(new [] {"hold", "approve", "spam"}));
        }
    }
}
