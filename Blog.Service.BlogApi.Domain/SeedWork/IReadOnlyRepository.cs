using Blog.Service.BlogApi.Domain.QueryMapper;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Domain.SeedWork
{
    public interface IReadOnlyRepository<T, TEntity>
    {
        IEnumerable<TEntity> GetMultiple(QueryOptions options);

        TEntity Get(T id);
    }
}
