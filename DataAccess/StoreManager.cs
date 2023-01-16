using DataAccess.Models;
using MongoDB.Driver;

namespace DataAccess;

public class StoreManager : IRepository<Customer>
{
    private readonly IMongoCollection<Customer> _customerCollection;

    public StoreManager()
    {
        var hostname = "localhost";
        var databaseName = "lab3-mongoDB";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        _customerCollection = database.GetCollection<Customer>("Customer", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public void Add(Customer item)
    {
        _customerCollection.InsertOne(item);
    }
}