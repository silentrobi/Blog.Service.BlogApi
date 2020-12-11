using Blog.Service.BlogApi.Domain.SeedWork;

namespace Blog.Service.BlogApi.Domain.Users 
{
    public interface IUserReadOnlyRepository : IReadOnlyRepository<string, User>
    {

    }
}
