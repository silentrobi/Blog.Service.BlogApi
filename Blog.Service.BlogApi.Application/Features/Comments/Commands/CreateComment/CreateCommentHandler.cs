using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Service.BlogApi.Application.Commands.CreateComment;
using Blog.Service.BlogApi.Domain.Comments;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Users;
using MediatR;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentHandler(IBlogUnitOfWork blogUnitOfWork, IMapper mapper)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment entity = _mapper.Map<Comment>(request.CreateCommentDto);

            entity.LikedUsers = new List<string>();
            entity.CreatedAt = DateTime.Now;

            try
            {
                _blogUnitOfWork.CommentCommandRepository.Create(request.PostId, entity);
            }
            catch 
            {
                throw new Exceptions.ApplicationException("Failed to add new comment to the post");
            }
            
            return true;
        }
    }
}
