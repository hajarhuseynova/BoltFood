using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IProductService
    {

        public Task<string> CreateAsync(string name, double price, int RestaurantId, ProductCategory PrdctCategory);
        public Task<string> RemoveAsync(int id);

        public Task<string> UpdateAsync(int id, string name, double price);

        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetAsync(int id);
    }
}
 