using System;
using CookComputing.XmlRpc;

namespace JoeBlogs
{
    /// <summary>
    /// A comment on a blog item
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct XmlRpcComment
    {
        public int post_id;

        public int comment_parent;
        public string content;
        public string author;
        public string author_url;
        public string author_email;
    }

    /// <summary>
    /// A comment on a blog item
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct XmlRpcCommentResponse
    {
        public DateTime dateCreated;
        public string user_id;
        public string comment_id;
        public string parent;
        public string status;
        public string content;
        public string link;
        public string post_id;
        public string post_title;
        public string author;
        public string author_url;
        public string author_email;
        public string author_ip;
    }
}