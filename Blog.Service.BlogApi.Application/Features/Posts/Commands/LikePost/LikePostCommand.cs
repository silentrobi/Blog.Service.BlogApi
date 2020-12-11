using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.LikePost
{
    public class LikePostCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

    }
}
