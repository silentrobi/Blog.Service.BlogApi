using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
