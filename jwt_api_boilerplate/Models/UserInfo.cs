using System;

namespace jwt_api_boilerplate.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
