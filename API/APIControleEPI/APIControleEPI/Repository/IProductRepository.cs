using APIControleEPI.Models;

namespace APIControleEPI.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsPerCategory(int categoryId);
    }
}
