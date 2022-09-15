using GraphQLBeginners.Data;
using GraphQLBeginners.Interfaces;
using GraphQLBeginners.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBeginners.Services
{
    public class ProductService : IProduct
    {
        private readonly GraphQLDbContext _context;

        public ProductService(GraphQLDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            product.Id = 0;
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);

            if (product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Update(int id, Product product)
        {
            var existing = await GetById(id);

            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                _context.Products.Update(existing);

                await _context.SaveChangesAsync();
            }

            return product;
        }
    }
}
