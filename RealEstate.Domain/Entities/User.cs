using System.Collections.Generic;

namespace RealEstate.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AppId { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
