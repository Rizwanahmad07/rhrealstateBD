using Amazon.DynamoDBv2.DataModel;

namespace RealEstate.Domain.Entities
{
    [DynamoDBTable("UserRoles")]
    public class UserRole
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string AppId { get; set; }
        
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
