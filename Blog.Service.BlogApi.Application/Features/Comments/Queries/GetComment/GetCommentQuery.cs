using Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork;
using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComment
{
    public class GetCommentQuery : IRequest<CommentDto>
    {
        public string Id { get; set; }
        public string PostId { get; set; }
    }
}
