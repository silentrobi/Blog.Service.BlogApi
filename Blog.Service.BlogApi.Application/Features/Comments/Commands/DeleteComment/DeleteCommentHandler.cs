using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public DeleteCommentHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Comment entity = _blogUnitOfWork.CommentReadOnlyRepository.Get(request.PostId, request.Id);

            if (entity == null) throw new Exceptions.ApplicationException("No comment is found to delete");

            if (!entity.UserId.Equals(request.UserId))
            {
                throw new Exceptions.ApplicationException("Unauthorized to delete comment"); //need new exeption model class
            }

            var isSucceed = _blogUnitOfWork.CommentCommandRepository.Delete(request.PostId ,request.Id);

            if (!isSucceed) throw new Exceptions.ApplicationException("Failed to update comment");

            return true;
        }
    }
}
