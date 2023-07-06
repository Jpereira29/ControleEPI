using APIControleEPI.Context;
using APIControleEPI.Models;

namespace APIControleEPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
