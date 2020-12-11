using Autofac;
using Blog.Service.BlogApi.Application.Interfaces;
using Blog.Service.BlogApi.Application.Services;

namespace Blog.Service.BlogApi.Application
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
