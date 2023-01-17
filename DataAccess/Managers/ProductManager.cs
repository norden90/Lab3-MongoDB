using DataAccess.Models;
using MongoDB.Driver;
using System;

namespace DataAccess.Managers;

public class ProductManager : IRepository<Product>
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductManager()
    {
        var hostname = "localhost";
        var databaseName = "Lab3-MongoDB";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _productCollection = database.GetCollection<Product>("Products", new MongoCollectionSettings() 
            { AssignIdOnInsert = true });
    }
    public void Add(Product item)
    {
        _productCollection.InsertOne(item);
    }

    public IEnumerable<Product> GetAll()
    {
        return _productCollection.Find(_ => true).ToEnumerable();
    }

    public IEnumerable<Product> GetById(object id)
    {
        return null;
    }

    public void Replace(object id, Product item)
    {
        return;
    }

    public void Delete(object id)
    {
        var filter = Builders<Product>.Filter.Eq("Id", id);
        _productCollection.DeleteOne(filter);
    }
}