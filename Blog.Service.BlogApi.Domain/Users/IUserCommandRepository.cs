using Blog.Service.BlogApi.Domain.SeedWork;

namespace Blog.Service.BlogApi.Domain.Users 
{
    public interface IUserCommandRepository : ICommandRepository<string, User>
    {
        
    }
}