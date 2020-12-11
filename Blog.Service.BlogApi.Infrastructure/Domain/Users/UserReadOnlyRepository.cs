using Blog.Service.BlogApi.Domain.QueryMapper;
using Blog.Service.BlogApi.Domain.Users;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Users
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository
    {
        private readonly IBlogContext _context;

        public UserReadOnlyRepository(IBlogContext context)
        {
            _context = context;
        }

        public User Get(string id)
        {
            try
            {
                return _context.Users.Find(user => user.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetMultiple(QueryOptions options)
        {
            try
            {
                return _context.Users.Find(user => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
