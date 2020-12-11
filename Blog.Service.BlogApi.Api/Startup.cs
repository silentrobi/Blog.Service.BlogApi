using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Service.BlogApi.Infrastructure.Configurations;
using Blog.Service.BlogApi.Infrastructure.Contexts;
using AutoMapper;
using System;
using Autofac;
using Blog.Service.BlogApi.Application;
using Blog.Service.BlogApi.Api.Services;
using Blog.Service.BlogApi.Api.Extensions;
using FluentValidation;
using System.Reflection;
using Blog.Service.BlogApi.Infrastructure.Domain;

namespace Blog.Service.BlogApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            //DB Config
            services.Configure<BlogConfiguration>(
                options =>
                {
                    options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDB:Database").Value;
                }
            );
            services.AddSingleton<IBlogContext, BlogContext>();

            //Auto Mapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddSwagger();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new MediatorModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDoc();

            app.UseErrorHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
