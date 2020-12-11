using AutoMapper;
using Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork;
using Blog.Service.BlogApi.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.SeedWork
{
    [AutoMap(typeof(Post), ReverseMap = true)]
    public class PostDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public List<string> Uploads { get; set; }

        public List<CommentDto> Comments { get; set; }

        [IgnoreMap]
        public int CommentCount => Comments.Count();

        public string UserId { get; set; }

        public List<string> LikedUsers { get; set; }

        [IgnoreMap]
        public int Likes => LikedUsers.Count;
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}