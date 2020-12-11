using Autofac;
using Blog.Service.BlogApi.Application.Behaviours;
using Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost;
using MediatR;
using System.Reflection;

namespace Blog.Service.BlogApi.Api.Services
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(CreatePostCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
