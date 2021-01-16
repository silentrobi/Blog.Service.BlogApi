using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;

namespace Blog.Service.BlogApi.Infrastructure.Repositories
{
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        public BlogUnitOfWork(
        IPostReadOnlyRepository postReadOnlyRepository,
        IPostCommandRepository postCommandRepository,
        ICommentReadOnlyRepository commentReadOnlyRepository,
        ICommentCommandRepository commentCommandRepository)
        {
            PostReadOnlyRepository = postReadOnlyRepository;
            PostCommandRepository = postCommandRepository;
            CommentReadOnlyRepository = commentReadOnlyRepository;
            CommentCommandRepository = commentCommandRepository;
        }

        public IPostReadOnlyRepository PostReadOnlyRepository { get; }

        public IPostCommandRepository PostCommandRepository { get; }

        public ICommentReadOnlyRepository CommentReadOnlyRepository { get; }

        public ICommentCommandRepository CommentCommandRepository { get; }
    }
}