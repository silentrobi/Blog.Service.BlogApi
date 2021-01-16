using Autofac;
using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Infrastructure.Domain.Comments;
using Blog.Service.BlogApi.Infrastructure.Domain.Posts;
using Blog.Service.BlogApi.Infrastructure.Repositories;

namespace Blog.Service.BlogApi.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>().As<IPostReadOnlyRepository>().InstancePerLifetimeScope();

            builder.RegisterType<PostCommandRepository>().As<IPostCommandRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CommentReadOnlyRepository>().As<ICommentReadOnlyRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CommentCommandRepository>().As<ICommentCommandRepository>().InstancePerLifetimeScope();
        }
    }
}
