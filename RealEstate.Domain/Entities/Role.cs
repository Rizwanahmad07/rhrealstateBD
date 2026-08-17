using System.Collections.Generic;

namespace RealEstate.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
