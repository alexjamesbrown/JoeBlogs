using System.Collections.Generic;

namespace JoeBlogs
{
    public interface IWordPressWrapper : IMetaWeblogWrapper
    {
        bool DeleteCategory(int categoryID);
        bool DeleteComment(string comment_id);
        bool DeletePage(string pageID);
        bool EditComment(NewComment comment);
        bool EditPage(int pageID, Page editedPage);
        IEnumerable<Author> GetAuthors();
        Comment GetComment(string comment_id);
        CommentCount GetCommentCount(string post_id);
        IEnumerable<Comment> GetComments(int post_id, string status, int number, int offset);
        IEnumerable<string> GetCommentStatusList(string post_id);
        IEnumerable<Option> GetOptions(string[] options);
        Page GetPage(string pageid);
        IEnumerable<PageMin> GetPageList();
        IEnumerable<Page> GetPages();
        IEnumerable<string> GetPageStatusList();
        IEnumerable<PageTemplate> GetPageTemplates();
        IEnumerable<string> GetPostStatusList();
        IEnumerable<Tag> GetTags();
        int NewCategory(CategoryNew category);
        int NewCategory(string name, string slug, int parentId, string description);
        string NewComment(int postid, NewComment comment);
        string NewPage(Page page, bool publish);
        IEnumerable<Option> SetOptions();
        IEnumerable<CategoryMin> SuggestCategories(string startsWith, int max_results);
        File UploadFile(Data data);
    }
}