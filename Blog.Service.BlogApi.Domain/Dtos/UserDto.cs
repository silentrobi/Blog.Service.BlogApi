using System;
using AutoMapper;
using Blog.Service.BlogApi.Domain.Users;

namespace Blog.Service.BlogApi.Domain.Dtos
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [IgnoreMap]
        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [IgnoreMap]
        public string Age => BirthDate == DateTime.MinValue ? "" : (DateTime.Today.Year - BirthDate.Year).ToString();

        public string Profession { get; set; }
    }
}