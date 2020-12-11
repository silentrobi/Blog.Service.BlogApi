using System.Collections.Generic;
using Blog.Service.BlogApi.Domain.SeedWork;
using MongoDB.Bson;

namespace Blog.Service.BlogApi.Domain.Comments
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
        public string Content { get; set; }

        public int Likes { get; set; }

        public string UserId { get; set; }

        public List<string> LikedUsers { get; set; }

        public string ParentCommentId { get; set; }
    }
}