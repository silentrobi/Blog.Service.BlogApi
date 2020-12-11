namespace Blog.Service.BlogApi.Domain.SeedWork
{
    public interface ICommandRepository<T, TEntity>
    {
        void Create(TEntity entity);

        bool Update(T id, TEntity entity);
        
        bool Delete(T id);
    }
}
