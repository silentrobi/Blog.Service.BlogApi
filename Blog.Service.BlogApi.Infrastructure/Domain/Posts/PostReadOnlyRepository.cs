using System.Collections.Generic;
using System;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using Blog.Service.BlogApi.Domain.QueryMapper;
using Blog.Service.BlogApi.Domain.Posts;

namespace Blog.Service.BlogApi.Infrastructure.Domain.Posts
{
    public class PostReadOnlyRepository : IPostReadOnlyRepository
    {
        private readonly IBlogContext _context;

        public PostReadOnlyRepository(IBlogContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetMultiple(QueryOptions options)
        {
            try
            {
                if (options.Sort?.Trim().ToLower() == "asc")
                {
                    PropertyInfo sortByProperty = typeof(Post).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ?? typeof(Post).GetProperty("UpdatedAt");
                    if (options.UserId == null)
                    {
                        return _context.Posts.AsQueryable().OrderBy(sortByProperty.Name).Take(options.Limit).ToList();
                    }
                    else
                    {
                        return _context.Posts.AsQueryable().Where(post => post.UserId == options.UserId).OrderBy(sortByProperty.Name).Take(options.Limit).ToList();
                    }
                }
                else
                {
                    var sortByProperty = typeof(Post).GetProperty(options.SortBy?.Trim() ?? "UpdatedAt") ?? typeof(Post).GetProperty("UpdatedAt");

                    if (options.UserId == null)
                    {
                        System.Diagnostics.Debug.WriteLine("hi");
                        return _context.Posts.AsQueryable().OrderBy($"{sortByProperty.Name} DESC").Take(options.Limit).ToList();
                    }
                    else
                    {
                        return _context.Posts.AsQueryable().Where(post => post.UserId == options.UserId)
                                .OrderBy($"{sortByProperty.Name} DESC").Take(options.Limit).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Post Get(string id)
        {
            try
            {
                return _context.Posts.Find(post => post.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}