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
            var isSucceed = _blogUnitOfWork.CommentCommandRepository.Delete(request.PostId ,request.Id);

            if (!isSucceed) throw new Exceptions.ApplicationException("Failed to update comment");


            return true;
        }
    }
}
