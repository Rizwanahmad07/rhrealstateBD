using Amazon.DynamoDBv2.DataModel;

namespace RealEstate.Domain.Entities
{
    [DynamoDBTable("Features")]
    public class Feature
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FeatureImages { get; set; }
        public string AppId { get; set; }
    }
}
