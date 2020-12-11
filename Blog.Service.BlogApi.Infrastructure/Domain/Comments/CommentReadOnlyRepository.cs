using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Comments
{
    public class CommentReadOnlyRepository : ICommentReadOnlyRepository
    {
        private readonly IBlogContext _context;

        public CommentReadOnlyRepository(IBlogContext context)
        {
            _context = context;

        }

        public Comment Get(string postId, string id)
        {
            try
            {
                return _context.Posts.AsQueryable().Where(post => post.Id == postId)
                    .SelectMany(post => post.Comments).Where(comment => comment.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Comment> GetMultiple(string postId)
        {
            try
            {
                return _context.Posts.AsQueryable().Where(post => post.Id == postId)
                    .SelectMany(post => post.Comments).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
