using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<bool>
    {
        public UpdatePostDto UpdatePostDto { get; set; }

        public string Id { get; set; }

        public string UserId { get; set; }
    }
}