using AutoMapper;
using Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork;
using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComment
{
    public class GetCommentHandler : IRequestHandler<GetCommentQuery, CommentDto>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public GetCommentHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            Comment entity = _blogUnitOfWork.CommentReadOnlyRepository.Get(request.PostId, request.Id);

            return _mapper.Map<CommentDto>(entity);
        }
    }
}
