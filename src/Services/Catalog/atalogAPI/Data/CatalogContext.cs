using CatalogAPI.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var clients = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectioString"));
            var database = clients.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

        }
        public IMongoCollection<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
