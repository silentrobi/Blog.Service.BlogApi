using Blog.Service.BlogApi.Application.Features.Posts.Queries.SeedWork;
using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPost
{
    public class GetPostQuery : IRequest<PostDto>
    {
        public string Id { get; set; }
    }
}
