using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Interfaces
{
    public interface IProductsRepository
    {
       Task<List<Products>> GetAllAsync();

       Task<Products> GetByIdAsync(int id);

       Task<Products> CreateAsync(Products product);

       Task UpdateAsync (Products product);

       Task RemoveAsync(int id);     
    }
}
