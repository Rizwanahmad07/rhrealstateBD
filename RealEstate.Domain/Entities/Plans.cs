using Amazon.DynamoDBv2.DataModel;

namespace RealEstate.Domain.Entities
{
    [DynamoDBTable("Plans")]
    public class Plans
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlanImage { get; set; }
        public string AppId { get; set; }
    }
}
