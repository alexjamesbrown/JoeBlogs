
namespace JoeBlogs
{
    public class CommentCount
    {
        /// <summary>
        /// The number of comments marked as approved.
        /// </summary>
        public int Approved;

        /// <summary>
        /// The number of comments awaiting moderation
        /// </summary>
        public int AwaitingModeration;

        /// <summary>
        /// The number of comments marked as spam
        /// </summary>
        public int Spam;

        /// <summary>
        /// The total number of comments.
        /// </summary>
        public int TotalComments;
    }
}