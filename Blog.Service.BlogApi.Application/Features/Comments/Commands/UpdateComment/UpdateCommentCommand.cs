using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<bool>
    {
        public UpdateCommentDto UpdateCommentDto { get; set; }
        public string Id { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }

    }
}
