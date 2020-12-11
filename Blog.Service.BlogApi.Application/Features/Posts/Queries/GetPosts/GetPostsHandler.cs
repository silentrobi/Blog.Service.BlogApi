using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Application.Features.Posts.Queries.SeedWork;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public GetPostsHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var entities = _blogUnitOfWork.PostReadOnlyRepository.GetMultiple(request.QueryOptions);

            return _mapper.Map<IEnumerable<PostDto>>(entities);
        }
    }
}
