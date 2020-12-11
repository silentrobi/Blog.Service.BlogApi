using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Users;

namespace Blog.Service.BlogApi.Infrastructure.Repositories
{
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        public BlogUnitOfWork(
        IPostReadOnlyRepository postReadOnlyRepository,
        IPostCommandRepository postCommandRepository,
        ICommentReadOnlyRepository commentReadOnlyRepository,
        ICommentCommandRepository commentCommandRepository,
        IUserCommandRepository userCommandRepository,
        IUserReadOnlyRepository userReadOnlyRepository)
        {
            PostReadOnlyRepository = postReadOnlyRepository;
            PostCommandRepository = postCommandRepository;
            CommentReadOnlyRepository = commentReadOnlyRepository;
            CommentCommandRepository = commentCommandRepository;
            UserReadOnlyRepository = userReadOnlyRepository;
            UserCommandRepository = userCommandRepository;
        }

        public IPostReadOnlyRepository PostReadOnlyRepository { get; }

        public IPostCommandRepository PostCommandRepository { get; }

        public ICommentReadOnlyRepository CommentReadOnlyRepository { get; }

        public ICommentCommandRepository CommentCommandRepository { get; }

        public IUserReadOnlyRepository UserReadOnlyRepository { get; }

        public IUserCommandRepository UserCommandRepository { get; }

    }
}