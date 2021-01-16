using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Posts;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Users;
using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public CreatePostHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post entity = _mapper.Map<Post>(request.CreatePostDto);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.Comments = new List<Comment>();
            entity.Uploads = request.CreatePostDto.Uploads == null || request.CreatePostDto.Uploads.Count == 0 ? new List<string>() : request.CreatePostDto.Uploads;
            entity.LikedUsers = new List<string>();

            try
            {
                _blogUnitOfWork.PostCommandRepository.Create(entity);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to add new post");
            }
         
            return true;
        }
    }
}
