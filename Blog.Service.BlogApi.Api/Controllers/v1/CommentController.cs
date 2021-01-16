using Blog.Service.BlogApi.Application.Commands.CreateComment;
using Blog.Service.BlogApi.Application.Features.Comments.Commands.CreateComment;
using Blog.Service.BlogApi.Application.Features.Comments.Commands.DeleteComment;
using Blog.Service.BlogApi.Application.Features.Comments.Commands.LikeComment;
using Blog.Service.BlogApi.Application.Features.Comments.Commands.UnlikeComment;
using Blog.Service.BlogApi.Application.Features.Comments.Commands.UpdateComment;
using Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComment;
using Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/blog/posts/{postId}/comments")]
    [Authorize]
    public class CommentController : BaseController
    {
        public CommentController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(string postId, [FromBody] CreateCommentDto createCommentDto)
        {
            var result = await Mediator.Send(new CreateCommentCommand
            {
                CreateCommentDto = new CreateCommentDto(createCommentDto, AuthorizedUserId),
                PostId = postId
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(string postId)
        {
            var results = await Mediator.Send(new GetCommentsQuery
            {
                PostId = postId
            });

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(string postId, string id)
        {
            var result = await Mediator.Send(new GetCommentQuery
            {
                PostId = postId,
                Id = id
            });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(string postId, string id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var result = await Mediator.Send(new UpdateCommentCommand
            {
                UpdateCommentDto = updateCommentDto,
                PostId = postId,
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string postId, string id)
        {
            var result = await Mediator.Send(new DeleteCommentCommand
            {
                PostId = postId,
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikeComment(string postId, string id)
        {
            var result = await Mediator.Send(new LikeCommentCommand
            {
                PostId = postId,
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpPost("{id}/unlike")]
        public async Task<IActionResult> UnlikeComment(string postId, string id, [FromQuery] string userId)
        {
            var result = await Mediator.Send(new UnlikeCommentCommand
            {
                PostId = postId,
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }
    }
}
