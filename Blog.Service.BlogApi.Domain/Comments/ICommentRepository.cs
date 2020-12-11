using System.Collections.Generic;

namespace Blog.Service.BlogApi.Domain.Comments
{
    public interface ICommentReadOnlyRepository
    {
        IEnumerable<Comment> GetMultiple(string postId);

        Comment Get(string postId, string id);
    }
}