using Blog.Service.BlogApi.Domain.SeedWork;

namespace Blog.Service.BlogApi.Domain.Posts
{
    public interface IPostReadOnlyRepository: IReadOnlyRepository<string, Post>
    {
  
    }
}
