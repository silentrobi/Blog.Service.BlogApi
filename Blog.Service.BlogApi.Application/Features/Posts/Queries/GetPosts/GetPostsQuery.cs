using Blog.Service.BlogApi.Application.Features.Posts.Queries.SeedWork;
using Blog.Service.BlogApi.Domain.QueryMapper;
using MediatR;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<IEnumerable<PostDto>>
    {
        public QueryOptions QueryOptions { get; set; }
    }
}
