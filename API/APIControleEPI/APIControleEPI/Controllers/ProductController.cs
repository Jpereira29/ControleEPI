using APIControleEPI.Models;
using APIControleEPI.Repository.UnitOFWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIControleEPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProductController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("Category/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsPerCategory(int categoryId)
        {
            return Ok(await _uof.ProductRepository.GetProductsPerCategory(categoryId));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _uof.ProductRepository.GetById(c => c.ProdutId == id);
                if (product is null)
                {
                    return NotFound("Produto não encontrado!");
                }
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            try
            {
                var hasCategory = await _uof.CategoryRepository.GetById(c => c.CategoryId == product.CategoryId);
                if(hasCategory is null)
                {
                    return BadRequest("Esta categoria não existe!");
                }

                var hasProduct = await _uof.ProductRepository.GetById(c => c.Name == product.Name);
                if (hasProduct is null)
                {
                    _uof.ProductRepository.Add(product);
                    await _uof.Commit();

                    return Ok();
                }
                return BadRequest("Produto já existe!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.ProdutId)
                {
                    return BadRequest();
                }

                var hasProduct = await _uof.ProductRepository.GetById(c => c.Name == product.Name && c.ProdutId != product.ProdutId);
                if (hasProduct is null)
                {
                    _uof.ProductRepository.Update(product);
                    await _uof.Commit();

                    return Ok();
                }

                return BadRequest("Produto já existe!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _uof.ProductRepository.GetById(p => p.ProdutId == id);

                if (product is null)
                {
                    return NotFound();
                }
                _uof.ProductRepository.Delete(product);
                await _uof.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }
    }
}
