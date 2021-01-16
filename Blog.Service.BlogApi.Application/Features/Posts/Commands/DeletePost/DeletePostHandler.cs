using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Posts;

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
            Post entity = _blogUnitOfWork.PostReadOnlyRepository.Get(request.Id);

            if (entity == null) throw new Exceptions.ApplicationException("No Post is found to delete");

            if (!entity.UserId.Equals(request.UserId))
            {
                throw new Exceptions.ApplicationException("Unauthorized to delete post"); //need new exeption model class
            }

            var isSucceed = _blogUnitOfWork.PostCommandRepository.Delete(request.Id);

            if (!isSucceed) throw new Exceptions.ApplicationException("Post is not deleted successfully");

            return true;
        }
    }
}
