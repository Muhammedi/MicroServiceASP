using CatalogAPI.Data;
using CatalogAPI.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Reposatory
{
    public class ProductRepo : IProductRepo
    {
        public ProductRepo(ICatalogContext context)
        {
            _context = context;
        }

        public ICatalogContext _context { get; }

        public async  Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }
        public async Task<Product> Getbyid(string id)
        {
           
            return await _context.Products.Find(x=>x.ID==id).FirstOrDefaultAsync();
        }

         async Task IProductRepo.CreateProduct(Product pr)
        {
             await _context.Products.InsertOneAsync(pr);
        }

         async Task<bool> IProductRepo.DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ID ,id);
            var deleteresult= await _context.Products.DeleteOneAsync(filter);
            return deleteresult.IsAcknowledged && deleteresult.DeletedCount > 0;
        }     

         async Task<IEnumerable<Product>> IProductRepo.GetbyCategoryName(string CategoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(x => x.Category, CategoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

      

         async Task<IEnumerable<Product>> IProductRepo.GetbyProductName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(x => x.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
            
        }

        async Task<bool> IProductRepo.UpdatePRoduct(Product pr)
        {
            var res = await _context.Products.ReplaceOneAsync(filter: p => p.ID == pr.ID, replacement: pr);
           
            return res.IsAcknowledged
                            && res.ModifiedCount > 0; 
        }
    }
}
