using System;

namespace JoeBlogs
{
    public class Post
    {
        private int _postID;

        public Post()
        {
            DateCreated = DateTime
                .Now;
        }

        public int PostID { get { return _postID; } }

        public DateTime DateCreated { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public int[] Categories { get; set; }
        public string[] Tags { get; set; }

        public override string ToString()
        {
            return this.Body;
        }
    }
}