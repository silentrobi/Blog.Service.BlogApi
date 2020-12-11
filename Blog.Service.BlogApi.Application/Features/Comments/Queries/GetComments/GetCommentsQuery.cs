using Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork;
using Blog.Service.BlogApi.Domain.QueryMapper;
using MediatR;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComments
{
    public class GetCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {
        public string PostId { get; set; }
        public QueryOptions QueryOptions { get; set; }
    }
}
