using Blog.Service.BlogApi.Application.Interfaces;
using Blog.Service.BlogApi.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Blog.Service.BlogApi.Domain.QueryMapper;

namespace Blog.Service.BlogApi.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/blog/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get User List
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUsers([FromQuery] QueryOptions options)
        {
            return Ok(_userService.GetUsers(options));
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(string id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserDto userDto)
        {
            _userService.CreateUser(userDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var (message, isSucceed) = _userService.UpdateUserById(id, userDto);

            if (!isSucceed) return BadRequest(message);

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var (message, isSucceed) = _userService.DeleteUserById(id);

            if (!isSucceed) return NotFound(message);

            return Ok(message);
        }
    }
}