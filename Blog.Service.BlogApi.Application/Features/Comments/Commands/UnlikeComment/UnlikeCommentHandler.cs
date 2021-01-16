using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.UnlikeComment
{
    public class UnlikeCommentHandler : IRequestHandler<UnlikeCommentCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public UnlikeCommentHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public async Task<bool> Handle(UnlikeCommentCommand request, CancellationToken cancellationToken)
        {
            Comment commentEntity = _blogUnitOfWork.CommentReadOnlyRepository.Get(request.PostId, request.Id);

            if (commentEntity == null)
            {
                throw new Exceptions.ApplicationException("No Comment is found to unlike");
            }

            if (commentEntity.LikedUsers.Count == 0 || !commentEntity.LikedUsers.Contains(request.UserId))
            {
                throw new Exceptions.ApplicationException("No like was given to the comment by the user");
            }


            commentEntity.LikedUsers.Remove(request.UserId); // removing from array

            var isSucceed = _blogUnitOfWork.CommentCommandRepository.Update(request.PostId, request.Id, commentEntity);

            if (!isSucceed)
            {
                throw new Exceptions.ApplicationException("Failed to remove like from the comment");
            }

            return true;
        }
    }
}
