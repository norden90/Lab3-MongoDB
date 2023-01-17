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

    public bool VerifyPassword(string pw)
    {
        return Password == pw;
    }
    public Customer AddCustomer()

    {
        Console.Clear();
        Console.Write("Skapa ditt nya konto här\n" +
                      "Ange ditt namn:"); string tempName = Console.ReadLine();
        Console.Write("Ange ett lösenord:"); string tempPass = Console.ReadLine();

        var customer = new Customer(tempName, tempPass);

        return customer;
    }

}