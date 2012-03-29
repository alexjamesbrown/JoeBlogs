using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoeBlogs.IntegrationTests
{
    [TestFixture]
    public class Can_read_posts : TestWithFakeServer
    {
        public Can_read_posts()
            : base("metaWeblog.getPost", @"<?xml version=""1.0""?>
<methodResponse>
  <params>
    <param>
      <value>
      <struct>
  <member><name>dateCreated</name><value><dateTime.iso8601>20120328T16:45:00</dateTime.iso8601></value></member>
  <member><name>userid</name><value><string>1108390</string></value></member>
  <member><name>postid</name><value><int>159179</int></value></member>
  <member><name>description</name><value><string>&lt;p class='mine_asset assetid_6029537536'&gt;
    &lt;br /&gt;
    
    &lt;img class='event-item-lol-image' src='http://chzmemebase.files.wordpress.com/2012/03/internet-memes-damn-right-richard-dawkins.jpg' alt=&quot;internet memes - Damn Right, Richard Dawkins&quot; title=&quot;internet memes - Damn rRght, Richard Dawkins&quot; height=&quot;282px&quot; width=&quot;500px&quot; /&gt;

&lt;/p&gt;
&lt;p&gt;
&lt;/p&gt;
&lt;p&gt;
        &lt;br /&gt;But, he wishes you would. He's just that sort of guy.
-JH

&lt;a href=&quot;http://chzb.gr/GC494l&quot; target=&quot;_blank&quot;&gt;Science Has Dropped&lt;/a&gt;&lt;br /&gt;
&lt;/p&gt;</string></value></member>
  <member><name>title</name><value><string>Damn Right, Richard Dawkins</string></value></member>
  <member><name>link</name><value><string>http://memebase.com/2012/03/28/internet-memes-damn-right-richard-dawkins/</string></value></member>
  <member><name>permaLink</name><value><string>http://memebase.com/2012/03/28/internet-memes-damn-right-richard-dawkins/</string></value></member>
  <member><name>categories</name><value><array><data>
  <value><string>Memes</string></value>
</data></array></value></member>
  <member><name>mt_excerpt</name><value><string>internet memes - Damn Right, Richard Dawkins</string></value></member>
  <member><name>mt_text_more</name><value><string></string></value></member>
  <member><name>wp_more_text</name><value><string></string></value></member>
  <member><name>mt_allow_comments</name><value><int>1</int></value></member>
  <member><name>mt_allow_pings</name><value><int>0</int></value></member>
  <member><name>mt_keywords</name><value><string>category:Memes, evolution, gravity, richard dawkins, theory</string></value></member>
  <member><name>wp_slug</name><value><string>internet-memes-damn-right-richard-dawkins</string></value></member>
  <member><name>wp_password</name><value><string></string></value></member>
  <member><name>wp_author_id</name><value><string>1108390</string></value></member>
  <member><name>wp_author_display_name</name><value><string>Cheezburger Network</string></value></member>
  <member><name>date_created_gmt</name><value><dateTime.iso8601>20120328T23:45:00</dateTime.iso8601></value></member>
  <member><name>post_status</name><value><string>publish</string></value></member>
  <member><name>custom_fields</name><value><array><data>
  <value><struct>
  <member><name>id</name><value><string>1582813</string></value></member>
  <member><name>key</name><value><string>assetid</string></value></member>
  <member><name>value</name><value><string>6029537536</string></value></member>
</struct></value>
  <value><struct>
  <member><name>id</name><value><string>1582812</string></value></member>
  <member><name>key</name><value><string>assettype</string></value></member>
  <member><name>value</name><value><string>0</string></value></member>
</struct></value>
</data></array></value></member>
  <member><name>wp_post_format</name><value><string>standard</string></value></member>
  <member><name>sticky</name><value><boolean>0</boolean></value></member>
  <member><name>date_modified</name><value><dateTime.iso8601>20120328T18:59:19</dateTime.iso8601></value></member>
  <member><name>date_modified_gmt</name><value><dateTime.iso8601>20120329T01:59:19</dateTime.iso8601></value></member>
  <member><name>wp_featured_image</name><value><string></string></value></member>
  <member><name>wp_featured_image_url</name><value><boolean>0</boolean></value></member>
</struct>
      </value>
    </param>
  </params>
</methodResponse>")
        {
        }

        [Test]
        public void Should_read_all_the_fields()
        {
            var post = wordpressWrapper.GetPostRaw(123);

            Assert.That(post.dateCreated.Minute, Is.EqualTo(45));
            Assert.That(post.userid, Is.EqualTo("1108390"));
        }
    }
}
