using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductContext _context;

        public ProductsRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Products> CreateAsync(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<List<Products>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Products product)
        {
            var unchangedEntity = await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();

        }
    }
}
