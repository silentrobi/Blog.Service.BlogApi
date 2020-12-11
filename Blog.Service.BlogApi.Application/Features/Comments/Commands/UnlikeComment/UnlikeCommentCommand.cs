using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.UnlikeComment
{
    public class UnlikeCommentCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}
