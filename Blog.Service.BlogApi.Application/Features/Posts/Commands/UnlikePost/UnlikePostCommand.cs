using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UnlikePost
{
    public class UnlikePostCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public string UserId { get; set; }
    }
}
