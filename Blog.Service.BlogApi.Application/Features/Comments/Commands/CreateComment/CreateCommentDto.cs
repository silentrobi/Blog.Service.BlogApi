using AutoMapper;
using Blog.Service.BlogApi.Domain.Comments;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.CreateComment
{
    [AutoMap(typeof(Comment), ReverseMap = true)]
    public class CreateCommentDto
    {
        public string Content { get; set; }

        public string ParentCommentId { get; set; }

        public string UserId { get; set; }

        public CreateCommentDto()
        {

        }

        public CreateCommentDto(CreateCommentDto createCommentDto, string userId)
        {
            Content = createCommentDto.Content;
            ParentCommentId = createCommentDto.ParentCommentId;
            UserId = userId;
        }
    }
}
