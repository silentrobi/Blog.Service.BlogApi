using Blog.Service.BlogApi.Domain.SeedWork;

namespace Blog.Service.BlogApi.Domain.Users 
{
    public class User: BaseEntity
    {
        public string Email { get; set; }

        public string SecurePassword { get; set; }

        public string PhoneNo { get; set; }
        
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string Profession { get; set; } 
    }
}
