using Blog.Service.BlogApi.Domain.Users;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;
using System;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Users
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly IBlogContext _context;

        public UserCommandRepository(IBlogContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            try
            {
                _context.Users.InsertOne(entity);
            }
            catch (MongoWriteConcernException ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
           try
            {
                DeleteResult actionResult = _context.Users.DeleteOne(user => user.Id == id);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(string id, User entity)
        {
            try
            {
                ReplaceOneResult actionResult = _context.Users.ReplaceOne(user => user.Id == id, entity);
                return actionResult.IsAcknowledged && actionResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}