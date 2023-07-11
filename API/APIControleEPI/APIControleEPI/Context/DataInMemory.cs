using APIControleEPI.Models;
using APIControleEPI.Repository.UnitOFWork;

namespace APIControleEPI.Context
{
    public class DataInMemory
    {
        private readonly IUnitOfWork _uof;

        public DataInMemory(IUnitOfWork context)
        {
            _uof = context;
        }

        public void AddCustomerData()
        {
            var categories = new List<Category>() {
                new Category
                {
                    CategoryId = 1,
                    Name = "Luvas",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Botas",
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Capacetes",
                }
            };

            var products = new List<Product>()
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Bota Bico de Ferro",
                    CategoryId = 2,
                    Description = "Bota bico de ferro para eletricistas e mecâncicos.",
                    Price = 90,
                    ImageUrl = "https://m.media-amazon.com/images/I/61PckbxV6mL._AC_UF1000,1000_QL80_.jpg"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Luva Eletrostática",
                    CategoryId = 1,
                    Description = "Luva eletrostática para eletricistas.",
                    Price = 10.95M,
                    ImageUrl= "https://m.media-amazon.com/images/I/61RlqTQMmXS._AC_SX569_.jpg"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Capacete de Seguraça",
                    CategoryId = 3,
                    Description = "Capacete de Seguraça.",
                    Price = 110.99M,
                    ImageUrl = "https://m.media-amazon.com/images/I/519NbsoDeHL._AC_UF894,1000_QL80_.jpg"
                }
            };

            categories.ForEach(c => _uof.CategoryRepository.Add(c));
            products.ForEach(p => _uof.ProductRepository.Add(p));
            _uof.Commit();
        }
    }
}
