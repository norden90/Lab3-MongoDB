using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public record Customer
{

    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement]
    private string Password{ get; set; } = string.Empty;

    [BsonElement] 
    public List<Product> Cart;



}