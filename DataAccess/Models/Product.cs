using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public class Product
{
    [BsonElement]
    public int Id { get; set; }
    [BsonElement]
    public string Name { get; set; }
    [BsonElement]
    public int Price { get; set; }
    [BsonElement]
    public int Amount { get; set; }

    public Product(string name, int price, int amount)
    {
        Name = name;
        Price = price;
        Amount = amount;
    }
    
}