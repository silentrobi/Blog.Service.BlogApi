using Blog.Service.BlogApi.Domain.SeedWork;
using System.Collections.Generic;
using Blog.Service.BlogApi.Domain.Comments;

namespace Blog.Service.BlogApi.Domain.Posts
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }

        public List<string> Uploads { get; set; }

        public List<string> LikedUsers { get; set; }

        public List<Comment> Comments { get; set; }

        public string UserId { get; set; }
    }
}