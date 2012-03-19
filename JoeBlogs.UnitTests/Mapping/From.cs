using NUnit.Framework;

namespace JoeBlogs.Tests.Mapping
{
    [TestFixture]
    public class From
    {
        [Test]
        public void can_map_from_author_to_xmlRpcAuthor()
        {
            var author = new Author();
            author.DisplayName = "Joe Blogs";
            author.LoginName = "joeBlogs";
            author.EmailAddress = "joe@blogs.com";
            author.UserID = "1234";

            var result = Map.From.Author(author);

            Assert.AreEqual(author.DisplayName, result.display_name);
            Assert.AreEqual(author.EmailAddress, result.user_email);
            Assert.AreEqual(author.LoginName, result.user_login);
            Assert.AreEqual(author.UserID, result.user_id);
        }

        [Test]
        public void can_map_from_category_to_xmlRpcCategory()
        {
            var category = new Category
                               {
                                   Name = "Test Category Name",
                                   Description = "This is a test category",
                                   HtmlUrl = "www.test.com/cat",
                                   ParentCategoryID = 1,
                                   RSSUrl = "www.testrssurl.com"
                               };

            var result = Map.From.Category(category);

            Assert.AreEqual(category.Name, result.categoryName);
            Assert.AreEqual(category.Description, result.description);
            Assert.AreEqual(category.HtmlUrl, result.htmlUrl);
            Assert.AreEqual(category.ParentCategoryID.ToString(), result.parentId);
            Assert.AreEqual(category.RSSUrl, result.rssUrl);
        }

        [Test]
        public void can_map_from_comment_to_xmlRpcComment()
        {
            var comment = new Comment
                              {
                                  AuthorEmail = "test@test.com",
                                  AuthorName = "Joe Blogs",
                                  AuthorUrl = "www.test.com",
                                  Content = "this is a test comment",
                              };

            var result = Map.From.Comment(comment);

            Assert.AreEqual(comment.AuthorEmail, result.author_email);
            Assert.AreEqual(comment.AuthorName, result.author);
            Assert.AreEqual(comment.AuthorUrl, result.author_url);
            Assert.AreEqual(comment.Content, result.content);
            Assert.AreEqual(comment.PostID, result.post_id);
            Assert.AreEqual(112233, result.parent);
        }

        [Test]
        public void can_map_from_commentCount_to_xmlRpcCommentCount()
        {
            var commentCount = new CommentCount
                                   {
                                       Approved = 1,
                                       AwaitingModeration = 2,
                                       Spam = 3,
                                       TotalComments = 4
                                   };

            var result = Map.From.CommentCount(commentCount);

            Assert.AreEqual(commentCount.Approved, result.approved);
            Assert.AreEqual(commentCount.AwaitingModeration, result.awaiting_moderation);
            Assert.AreEqual(commentCount.Spam, result.spam);
            Assert.AreEqual(commentCount.TotalComments, result.total_comments);
        }

        [Test]
        public void can_map_from_commentFilter_to_xmlRpcCommentFilter()
        {
            var original = new CommentFilter
                               {
                                   Number = 12,
                                   Offset = 4,
                                   PostID = 1234,
                                   Status = "aaa"
                               };

            var result = Map.From.CommentFilter(original);

            Assert.AreEqual(original.Number, result.number);
            Assert.AreEqual(original.Offset, result.offset);
            Assert.AreEqual(original.PostID, result.post_id);
            Assert.AreEqual(original.Status, result.status);
        }
    }
}