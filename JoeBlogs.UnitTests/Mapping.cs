using NUnit.Framework;
using System;

namespace JoeBlogs.Tests.Mapping
{
    [TestFixture]
    public class MapFrom
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
        public void can_map_from_categoryNew_to_xmlRpcCategoryNew()
        {
            var categoryNew = new CategoryNew
            {
                Name = "Test Category Name",
                Description = "This is a test category",
                ParentCategoryID = 1,
                Slug = "a-slug"
            };

            var result = Map.From.CategoryNew(categoryNew);

            Assert.AreEqual(categoryNew.Name, result.name);
            Assert.AreEqual(categoryNew.Description, result.description);
            Assert.AreEqual(categoryNew.ParentCategoryID.ToString(), result.parent_id.ToString());
            Assert.AreEqual(categoryNew.Slug, result.slug);
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
            var commentStatus = CommentStatus.Hold;

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

    public class MapTo
    {
        [Test]
        public void can_map_to_author_from_xmlRpcAuthor()
        {
            var author = new XmlRpcAuthor();
            author.display_name = "Joe Blogs";
            author.user_login = "joeBlogs";
            author.user_email = "joe@blogs.com";
            author.user_id = "1234";

            var result = Map.To.Author(author);

            Assert.AreEqual(author.display_name, result.DisplayName);
            Assert.AreEqual(author.user_email, result.EmailAddress);
            Assert.AreEqual(author.user_login, result.LoginName);
            Assert.AreEqual(author.user_id, result.UserID);
        }

        [Test]
        public void can_map_to_category_from_xmlRpcCategory()
        {
            var category = new XmlRpcCategory()
            {
                categoryId = "1234",
                categoryName = "Test Category Name",
                description = "This is a test category",
                htmlUrl = "www.test.com/cat",
                parentId = "11",
                rssUrl = "www.testrssurl.com",
                title = "Test Category"
            };

            var result = Map.To.Category(category);

            Assert.AreEqual(category.categoryId, result.CategoryID.ToString());
            Assert.AreEqual(category.parentId, result.ParentCategoryID.ToString());
            Assert.AreEqual(category.categoryName, result.Name);
            Assert.AreEqual(category.description, result.Description);
            Assert.AreEqual(category.htmlUrl, result.HtmlUrl);
            Assert.AreEqual(category.rssUrl, result.RSSUrl);
            Assert.AreEqual(category.title, result.Name);
        }

        [Test]
        public void can_map_to_comment_from_xmlRpcComment()
        {
            var statusEnum = CommentStatus.Approve;
            var statusEnumName = Enum.GetName(typeof(CommentStatus), statusEnum);

            var xmlRpcComment = new XmlRpcComment
            {
                author = "test author",
                author_email = "test@test.com",
                author_url = "www.test.com",
                parent = "0",
                content = "This is some test content",
                post_id = "234",
            };

            var result = Map.To.Comment(xmlRpcComment);

            Assert.AreEqual(xmlRpcComment.author, result.AuthorName);
            Assert.AreEqual(xmlRpcComment.author_email, result.AuthorEmail);
            Assert.AreEqual(xmlRpcComment.author_url, result.AuthorUrl);
            Assert.AreEqual(xmlRpcComment.parent, result.ParentCommentID);
            Assert.AreEqual(xmlRpcComment.content, result.Content);
        }
    }

    [TestFixture]
    public class General
    {
        [Test]
        public void trying_to_map_a_string_that_doesnt_correspond_to_enum_val_throws_exception()
        {
            var testItem = new XmlRpcComment
            {
            };

            Assert.Throws<ArgumentException>(delegate
            {
                Map.To.Comment(testItem);
            });
        }
    }
}