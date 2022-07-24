using CatalogAPI.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Data
{
    public class CatalogContextSeed
    {
        private static IEnumerable<Product> GetPreConfigurationProducts()
        {
            return new List<Product>() {

            new Product{ID="625452d2f" ,Name="HPLab",Category="Computer",Price=2545}


            };
        }

        public static void seedData(IMongoCollection<Product> CollectioPr )
        {
            bool result = CollectioPr.Find(x => true).Any();
            if(!result)
            {
                Task task = CollectioPr.InsertManyAsync(GetPreConfigurationProducts());
            }
        }
    }
}
