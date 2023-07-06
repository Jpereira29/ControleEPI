using APIControleEPI.Context;
using APIControleEPI.Models;

namespace APIControleEPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
