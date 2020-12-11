using AutoMapper;
using Blog.Service.BlogApi.Domain.Comments;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.UpdateComment
{
    [AutoMap(typeof(Comment), ReverseMap = true)]
    public class UpdateCommentDto
    {
        public string Content { get; set; }
    }
}
