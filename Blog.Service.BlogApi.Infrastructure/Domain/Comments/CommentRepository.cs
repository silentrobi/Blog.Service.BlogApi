using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;
using System;
using System.IO;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Comments
{
    public class CommentCommandRepository : ICommentCommandRepository
    {
        private readonly IBlogContext _context;

        public CommentCommandRepository(IBlogContext context)
        {
            _context = context;

        }

        public void Create(string postId, Comment entity)
        {
            try
            {
                var _update = Builders<Post>.Update.Push(post => post.Comments, entity);
                _context.Posts.UpdateOne(filter: post => post.Id == postId, update: _update);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public bool Delete(string postId, string id)
        {
            try
            {
                var _update = Builders<Post>.Update.PullFilter(post => post.Comments, comment => comment.Id == id);
                UpdateResult actionResult = _context.Posts.UpdateOne(filter: post => post.Id == postId, update: _update);

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public bool Update(string postId, string id, Comment entity)
        {
            try
            {
                var _filter = Builders<Post>.Filter.And(Builders<Post>.Filter.Eq(post => post.Id, postId),
                Builders<Post>.Filter.ElemMatch(post => post.Comments, Comment => Comment.Id == id));

                var _update = Builders<Post>.Update.Set(post => post.Comments[-1], entity);
                
                UpdateResult actionResult = _context.Posts.UpdateOne(filter: _filter, update: _update);

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
