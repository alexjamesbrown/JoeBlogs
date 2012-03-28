using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoeBlogs.IntegrationTests
{
    public class Can_read_Categories : TestWithFakeServer
    {
        public Can_read_Categories()
            : base("wp.getCategories", @"<?xml version=""1.0""?>
<methodResponse>
  <params>
    <param>
      <value>
      <array><data>

  <value><struct>
  <member><name>categoryId</name><value><string>34934647</string></value></member>
  <member><name>parentId</name><value><string>123</string></value></member>
  <member><name>description</name><value><string>Image lol</string></value></member>
  <member><name>categoryDescription</name><value><string></string></value></member>
  <member><name>categoryName</name><value><string>Image</string></value></member>
  <member><name>htmlUrl</name><value><string>http://totallylookslike.icanhascheezburger.com/category/image/</string></value></member>
  <member><name>rssUrl</name><value><string>http://totallylookslike.icanhascheezburger.com/category/image/feed/</string></value></member>
</struct></value>

</data></array>
      </value>
    </param>
  </params>
</methodResponse>
")
        {
        }

        [Test]
        public void Should_return_all_category_fields()
        {
            var category = wordpressWrapper.GetCategories().Single();

            Assert.That(category.CategoryID, Is.EqualTo(34934647));
            Assert.That(category.ParentCategoryID, Is.EqualTo(123));
            Assert.That(category.Description, Is.EqualTo("Image lol"));
            Assert.That(category.Name, Is.EqualTo("Image"));
            Assert.That(category.HtmlUrl, Is.EqualTo("http://totallylookslike.icanhascheezburger.com/category/image/"));
            Assert.That(category.RSSUrl, Is.EqualTo("http://totallylookslike.icanhascheezburger.com/category/image/feed/"));
        }
    }
}
