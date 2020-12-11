using System;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Posts
{
    public class PostCommandRepository : IPostCommandRepository
    {
        private readonly IBlogContext _context;

        public PostCommandRepository(IBlogContext context)
        {
            _context = context;
        }

        public void Create(Post entity)
        {
            try
            {
                _context.Posts.InsertOne(entity);
            }
            catch (MongoWriteConcernException ex)
            {
                throw ex;
            }
        }
        
        public bool Update(string id, Post entity)
        {
            try
            {
                ReplaceOneResult actionResult = _context.Posts.ReplaceOne(post => post.Id == id, entity);
                return actionResult.IsAcknowledged && actionResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                DeleteResult actionResult = _context.Posts.DeleteOne(post => post.Id == id);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}