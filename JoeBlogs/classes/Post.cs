﻿using System;

namespace JoeBlogs
{
    public class Post
    {
        public Post()
        {
            DateCreated = DateTime.Now;
            CommentsEnabled = true;
        }

        public int PostID { get; set; }

        public DateTime DateCreated { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string[] Categories { get; set; }
        public string[] Tags { get; set; }
        public CustomField[] CustomFields { get; set; }
        public Term[] Terms { get; set; }
        public string PostType { get; set; }
        public bool CommentsEnabled { get; set; }
        public string Slug { get; set; }


        public override string ToString()
        {
            return this.Body;
        }
    }
}