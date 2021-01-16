using AutoMapper;
using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.LikeComment
{
    public class LikeCommentHandler : IRequestHandler<LikeCommentCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public LikeCommentHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public async Task<bool> Handle(LikeCommentCommand request, CancellationToken cancellationToken)
        {
            Comment commentEntity = _blogUnitOfWork.CommentReadOnlyRepository.Get(request.PostId, request.Id);

            if (commentEntity == null)
            {
                throw new Exceptions.ApplicationException("No Comment is found to like");
            }

            if (commentEntity.LikedUsers.Count != 0 && commentEntity.LikedUsers.Contains(request.UserId)) 
            {
                throw new Exceptions.ApplicationException("User have already liked the comment");
            }
            
            commentEntity.LikedUsers.Add(request.UserId); // adding in array

            var isSucceed = _blogUnitOfWork.CommentCommandRepository.Update(request.PostId, request.Id, commentEntity);

            if (!isSucceed) 
            {
                throw new Exceptions.ApplicationException("Failed to add like to the comment");
            }

            return true;
        }
    }
}
