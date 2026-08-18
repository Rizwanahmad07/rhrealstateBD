using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("Amenties")]
public class Amenties
{
    [DynamoDBHashKey]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string AmentiesImage { get; set; }

    public required string AppId { get; set; }
}