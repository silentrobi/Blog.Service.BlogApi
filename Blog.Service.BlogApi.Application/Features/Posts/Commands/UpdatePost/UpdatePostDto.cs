using AutoMapper;
using Blog.Service.BlogApi.Domain.Posts;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UpdatePost
{
    [AutoMap(typeof(Post), ReverseMap = true)]
    public class UpdatePostDto
    {
        public string Content { get; set; }

        public List<string> Uploads { get; set; }
    }
}
