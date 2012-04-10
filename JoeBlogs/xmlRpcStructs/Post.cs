﻿using System;
using CookComputing.XmlRpc;

namespace JoeBlogs
{
    /// <summary> 
    /// This struct represents the information about a post that could be returned by the 
    /// EditPost(), GetRecentPosts() and GetPost() methods. 
    /// </summary> 
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct XmlRpcPost
    {
        public DateTime dateCreated;
        public string userid;
        public string description;
        public string title;
        public int postid;
        public string link;
        public string permaLink;
        public string[] categories;
        
        public string mt_excerpt;
        public string mt_text_more;
        public string wp_more_text;
        public int mt_allow_comments;
        public int mt_allow_pings;
        public string mt_keywords;
        public string wp_slug;
        public string wp_password;
        public string wp_author_id;
        public string wp_author_display_name;
        public string post_status;

        public CustomField[] custom_fields;

        public class CustomField
        {
            public string id;
            public string key;
            public string value;
        }

        public override string ToString()
        {
            return this.description;
        }
    }
}