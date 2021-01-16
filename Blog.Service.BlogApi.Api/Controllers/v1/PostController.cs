using Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost;
using Blog.Service.BlogApi.Application.Features.Posts.Commands.DeletePost;
using Blog.Service.BlogApi.Application.Features.Posts.Commands.LikePost;
using Blog.Service.BlogApi.Application.Features.Posts.Commands.UnlikePost;
using Blog.Service.BlogApi.Application.Features.Posts.Commands.UpdatePost;
using Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPost;
using Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPosts;
using Blog.Service.BlogApi.Domain.QueryMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Service.BlogApi.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/blog/posts")]
    [Authorize]
    public class PostController : BaseController
    {
        public PostController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] QueryOptions options)
        {
            var results = await Mediator.Send(new GetPostsQuery
            {
                QueryOptions = options
            });

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(string id)
        {
            var result = await Mediator.Send(new GetPostQuery
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            var result = await Mediator.Send(new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto(createPostDto, AuthorizedUserId)
            });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(string id, [FromBody] UpdatePostDto updatePostDto)
        {
            var result = await Mediator.Send(new UpdatePostCommand
            {
                UpdatePostDto = updatePostDto,
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var result = await Mediator.Send(new DeletePostCommand
            {
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikePost(string id)
        {
            var result = await Mediator.Send(new LikePostCommand
            {
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }

        [HttpPost("{id}/unlike")]
        public async Task<IActionResult> UnlikePost(string id)
        {
            var result = await Mediator.Send(new UnlikePostCommand
            {
                Id = id,
                UserId = AuthorizedUserId
            });

            return Ok(result);
        }
    }
}