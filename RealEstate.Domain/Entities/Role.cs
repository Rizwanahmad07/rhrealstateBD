using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace RealEstate.Domain.Entities
{
    [DynamoDBTable("Roles")]
    public class Role
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
