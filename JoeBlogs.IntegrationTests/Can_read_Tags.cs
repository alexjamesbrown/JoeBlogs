using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoeBlogs.IntegrationTests
{
    [TestFixture]
    public class Can_read_tags : TestWithFakeServer
    {
        public Can_read_tags()
            : base("wp.getTags", @"<?xml version=""1.0""?>
    <methodResponse>
      <params><param><value>
        <array><data>

          <value><struct>
          <member><name>tag_id</name><value><string>52340</string></value></member>
          <member><name>name</name><value><string>yay</string></value></member>
          <member><name>count</name><value><string>4</string></value></member>
          <member><name>slug</name><value><string>yay</string></value></member>
          <member><name>html_url</name><value><string>http://icanhascheezburger.com/tag/yay/</string></value></member>
          <member><name>rss_url</name><value><string>http://icanhascheezburger.com/tag/yay/feed/</string></value></member>
          </struct></value>

        </data></array>
      </value></param></params>
    </methodResponse>

    ")
        {
        }

        [Test]
        public void Should_read_all_tag_fields()
        {
            Tag results = wordpressWrapper.GetTags().Single();

            Assert.That(results.Name, Is.EqualTo("yay"));
        }
    }
}
