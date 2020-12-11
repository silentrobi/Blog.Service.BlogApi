namespace Blog.Service.BlogApi.Domain.Comments
{
    public interface ICommentCommandRepository
    {
        void Create(string postId, Comment entity);
        bool Update(string postId, string id, Comment entity);

        bool Delete(string postId, string id);
    }
}
