using Blog.Service.BlogApi.Application.Features.Comments.Commands.CreateComment;
using MediatR;

namespace Blog.Service.BlogApi.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public CreateCommentDto CreateCommentDto { get; set; }

        public string PostId { get; set; }
    }
}