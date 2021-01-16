using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.LikePost
{
    public class LikePostHandler : IRequestHandler<LikePostCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public LikePostHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public async Task<bool> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            Post postEntity = _blogUnitOfWork.PostReadOnlyRepository.Get(request.Id);

            if (postEntity == null) throw new Exceptions.ApplicationException("No Post is found to like");

            if (postEntity.LikedUsers.Count != 0 && postEntity.LikedUsers.Contains(request.UserId))
            {
                throw new Exceptions.ApplicationException("User have already liked the post");
            }

            postEntity.LikedUsers.Add(request.UserId); // adding in array

            var isSucceed = _blogUnitOfWork.PostCommandRepository.Update(request.Id, postEntity);

            if (!isSucceed) throw new Exceptions.ApplicationException("Like is not added successfully");

            return true;
        }
    }
}
