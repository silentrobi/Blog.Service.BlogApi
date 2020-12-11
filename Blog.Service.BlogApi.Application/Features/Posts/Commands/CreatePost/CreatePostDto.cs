using AutoMapper;
using Blog.Service.BlogApi.Domain.Posts;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost
{
    [AutoMap(typeof(Post), ReverseMap = true)]
    public class CreatePostDto
    {
        public string Content { get; set; }

        public List<string> Uploads { get; set; }

        public string UserId { get; set; }
    }
}