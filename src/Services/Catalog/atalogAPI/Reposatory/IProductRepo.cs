using CatalogAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Reposatory
{
    public interface IProductRepo
    {
         Task<IEnumerable<Product>> GetAll();
        Task<Product> Getbyid(string id);
        Task<IEnumerable<Product>> GetbyProductName(string name);
        Task<IEnumerable<Product>> GetbyCategoryName(string CategoryName);

        Task CreateProduct(Product pr);
        Task<bool> UpdatePRoduct(Product pr);
        Task<bool> DeleteProduct(string id);
    }
}
