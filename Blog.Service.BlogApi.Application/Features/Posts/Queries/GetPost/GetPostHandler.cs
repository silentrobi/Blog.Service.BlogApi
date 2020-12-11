using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Application.Features.Posts.Queries.SeedWork;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, PostDto>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public GetPostHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            Post entity = _blogUnitOfWork.PostReadOnlyRepository.Get(request.Id);

            return _mapper.Map<PostDto>(entity);
        }
    }
}
