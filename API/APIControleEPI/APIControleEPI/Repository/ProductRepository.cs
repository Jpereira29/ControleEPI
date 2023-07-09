using APIControleEPI.Context;
using APIControleEPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIControleEPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsPerCategory(int categoryId)
        {
            return await _context.Set<Product>().Where(p=> p.CategoryId == categoryId).ToListAsync();
        }
    }
}
