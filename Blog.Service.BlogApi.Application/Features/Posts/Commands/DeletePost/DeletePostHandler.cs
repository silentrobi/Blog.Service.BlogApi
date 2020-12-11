using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Blog.Service.BlogApi.Domain.Repositories;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public DeletePostHandler(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var isSucceed = _blogUnitOfWork.PostCommandRepository.Delete(request.Id);

            if (!isSucceed) throw new Exceptions.ApplicationException("Post is not deleted successfully");

            return true;
        }
    }
}
