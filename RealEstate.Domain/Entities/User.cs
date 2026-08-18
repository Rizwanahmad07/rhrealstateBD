using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace RealEstate.Domain.Entities
{
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AppId { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
