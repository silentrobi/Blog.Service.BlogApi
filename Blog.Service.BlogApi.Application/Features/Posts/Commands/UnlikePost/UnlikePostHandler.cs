using AutoMapper;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UnlikePost
{
    public class UnlikePostHandler : IRequestHandler<UnlikePostCommand,bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public UnlikePostHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public async Task<bool> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
        {
            Post postEntity = _blogUnitOfWork.PostReadOnlyRepository.Get(request.Id);

            if (postEntity == null) throw new Exceptions.ApplicationException("No Post is found to unlike");

            if (postEntity.LikedUsers.Count == 0 || !postEntity.LikedUsers.Contains(request.UserId)) 
            {
                throw new Exceptions.ApplicationException("Failed to perform operation as no like is found with given User Id");
            }

            postEntity.LikedUsers.Remove(request.UserId);

            var isSucceed = _blogUnitOfWork.PostCommandRepository.Update(request.Id, postEntity);

            if (!isSucceed) throw new Exceptions.ApplicationException("Like is not removed successfully");

            return true;
        }
    }
}
