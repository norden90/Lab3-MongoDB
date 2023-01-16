using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DataAccess.Models;

public class Customer
{
    
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string Name { get; set; }

    [BsonElement]
    public string Password { get; set; }
    [BsonElement]
    public List<Product> Cart
    {
        get { return _cart; }
    }
    #region Fields

    private List<Product> _cart;

    #endregion
    public Customer(string name, string password)
    {
        Name = name;
        Password = password;
        _cart = new List<Product>();
    }

}