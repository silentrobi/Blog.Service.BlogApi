using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Users;

namespace Blog.Service.BlogApi.Domain.Repositories
{
    public interface IBlogUnitOfWork
    {
        IPostReadOnlyRepository PostReadOnlyRepository { get; }
        IPostCommandRepository PostCommandRepository { get; }
        ICommentReadOnlyRepository CommentReadOnlyRepository { get; }
        ICommentCommandRepository CommentCommandRepository { get; }
        IUserCommandRepository UserCommandRepository { get; }
        IUserReadOnlyRepository UserReadOnlyRepository { get; }
    }
}