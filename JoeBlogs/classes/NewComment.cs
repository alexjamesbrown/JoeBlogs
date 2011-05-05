using System;

namespace JoeBlogs
{
    /// <summary>
    /// New comment on a post
    /// </summary>
    public class NewComment
    {
        protected NewComment() { }

        public NewComment(int postID)
            : this(postID, 0) { }

        public NewComment(int postID, int parentCommentID)
        {
            ParentCommentID = parentCommentID;
            PostID = postID;
        }

        /// <summary>
        /// Gets the post ID.
        /// </summary>
        public int PostID { get; private set; }

        /// <summary>
        /// Gets the parent comment ID, if this is a reply comment
        /// </summary>
        public int? ParentCommentID { get; private set; }

        /// <summary>
        /// Gets or sets the content, which is the comment body.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the name of the author of the comment.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the author of the comment
        /// </summary>
        /// <value>
        /// The author URL.
        /// </value>
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets the email address of the author of the comment.
        /// </summary>
        /// <value>
        /// The author email address
        /// </value>
        public string AuthorEmail { get; set; }
    }
}