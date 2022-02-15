using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString").ToString());
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName").ToString());
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName").ToString());
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
