using DataAccess.Models;
using MongoDB.Driver;
using System;

namespace DataAccess.Managers;

public class CustomerManager : IRepository<Customer>
{
    private readonly IMongoCollection<Customer> _customerCollection;

    public CustomerManager()
    {
        var hostname = "localhost";
        var databaseName = "Lab3-MongoDB";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _customerCollection = database.GetCollection<Customer>("Customers", new MongoCollectionSettings() 
            { AssignIdOnInsert = true });
    }

    public void Add(Customer item)
    {
        _customerCollection.InsertOne(item);
    }


    public IEnumerable<Customer> GetAll()
    {
        return _customerCollection.Find(_ => true).ToEnumerable();
    }

    public IEnumerable<Customer> GetById(object id)
    {
        return null;
    }

    public void Replace(object id, Customer item)
    {
        return;
    }

    public void Delete(object id)
    {
        return;
    }


}