using System.Collections.Generic;
using AutoMapper;
using Blog.Service.BlogApi.Domain.Comments;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.SeedWork
{
    [AutoMap(typeof(Comment), ReverseMap = true)]
    public class CommentDto
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public List<string> LikedUsers { get; set; }

        [IgnoreMap]
        public int Likes => LikedUsers.Count;

        public string ParentCommentId { get; set; }
    }
}