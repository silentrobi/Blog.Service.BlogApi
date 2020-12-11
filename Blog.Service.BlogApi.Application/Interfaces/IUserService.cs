using System.Collections.Generic;
using Blog.Service.BlogApi.Domain.Dtos;
using Blog.Service.BlogApi.Domain.QueryMapper;

namespace Blog.Service.BlogApi.Application.Interfaces
{
    public interface IUserService
    {
         void CreateUser(UserDto userDto);

         UserDto GetUserById(string id);

         IEnumerable<UserDto> GetUsers(QueryOptions options);

         (string, bool) UpdateUserById(string id, UserDto userDto);

         (string, bool) DeleteUserById(string id);
    }
}