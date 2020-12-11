using AutoMapper;
using Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork;
using Blog.Service.BlogApi.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComments
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public GetCommentsHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var entities = _blogUnitOfWork.CommentReadOnlyRepository.GetMultiple(request.PostId);

            return _mapper.Map<IEnumerable<CommentDto>>(entities);
        }
    }
}
