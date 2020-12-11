using System;
using System.Collections.Generic;
using AutoMapper;
using Blog.Service.BlogApi.Application.Interfaces;
using Blog.Service.BlogApi.Domain.Dtos;
using Blog.Service.BlogApi.Domain.QueryMapper;
using Blog.Service.BlogApi.Domain.Repositories;
using Blog.Service.BlogApi.Domain.Users;

namespace Blog.Service.BlogApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _mapper = mapper;
        }

        public void CreateUser(UserDto userDto)
        {
            User entity = _mapper.Map<User>(userDto);
            entity.CreatedAt = DateTime.Now;
            _blogUnitOfWork.UserCommandRepository.Create(entity);
        }

        public (string, bool) DeleteUserById(string id)
        {
            var isSucceed = _blogUnitOfWork.UserCommandRepository.Delete(id);

            if (!isSucceed) return ("User is not deleted successfully", false);

            return ("User is deleted successfully", false);
        }

        public UserDto GetUserById(string id)
        {
            User entity = _blogUnitOfWork.UserReadOnlyRepository.Get(id);

            return _mapper.Map<UserDto>(entity);
        }

        public IEnumerable<UserDto> GetUsers(QueryOptions options)
        {
            var entities = _blogUnitOfWork.UserReadOnlyRepository.GetMultiple(options);

            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }

        public (string, bool) UpdateUserById(string id, UserDto userDto)
        {
            User currentEntity = _blogUnitOfWork.UserReadOnlyRepository.Get(id);

            if (currentEntity == null) return ("No User is found to update", false);

            var updateEnitity = _mapper.Map<User>(userDto);
            
            //Non modifiable fields
            updateEnitity.SecurePassword= currentEntity.SecurePassword;

            var isSucceed = _blogUnitOfWork.UserCommandRepository.Update(id, updateEnitity);
            
            if (!isSucceed) return ("User is not updated successfully", false);

            return ("User is updated successfully", true);
        }
    }
}