﻿using System.Collections.Generic;

namespace JoeBlogs
{
    public interface IMetaWeblogWrapper
    {
        bool DeletePost(int postid);        
        IEnumerable<Category> GetCategories();
        JoeBlogs.Post GetPost(int postID);
        IEnumerable<Post> GetRecentPosts(int numberOfPosts);
        IEnumerable<UserBlog> GetUserBlogs();
        UserInfo GetUserInfo();
        MediaObjectInfo NewMediaObject(MediaObject mediaObject);
        int NewPost(Post post, bool publish);
    }
}