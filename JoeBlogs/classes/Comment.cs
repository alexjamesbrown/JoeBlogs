using System;

namespace JoeBlogs
{
    public class Comment
    {
        protected Comment() { }

        public Comment(int postID)
            : this(postID, 0) { }

        public Comment(int postID, int commentParentID)
        {
            CommentParentID = commentParentID;
            PostID = postID;
        }

        public int PostID { get; private set; }
        public int CommentParentID { get; private set; }

        public string Content { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string AuthorEmail { get; set; }
    }

    public class CommentResponse : Comment
    {
        public CommentResponse()
        {
        }

        public DateTime DateCreated { get; set; }
        public int UserID { get; set; }
        public int CommentID { get; set; }
        public CommentStatus Status { get; set; }
        public string Link { get; set; }
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string AuthorIP { get; set; }
    }
}