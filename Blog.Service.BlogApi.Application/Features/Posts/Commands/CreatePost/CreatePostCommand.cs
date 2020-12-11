using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<bool>
    {
        public CreatePostDto CreatePostDto { get; set; }
    }
}
