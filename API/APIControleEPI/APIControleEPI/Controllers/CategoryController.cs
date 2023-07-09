using APIControleEPI.Models;
using APIControleEPI.Repository.UnitOFWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIControleEPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CategoryController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            try
            {
                return Ok(await _uof.CategoryRepository.Get().ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                var category = await _uof.CategoryRepository.GetById(c=> c.CategoryId == id);
                if(category is null)
                {
                    return NotFound("Categoria não encontrada!");
                }
                return Ok(category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCategory(Category category)
        {
            try
            {
                var hasCategory = await _uof.CategoryRepository.GetById(c => c.Name == category.Name);
                if (hasCategory is null)
                {
                    _uof.CategoryRepository.Add(category);
                    await _uof.Commit();

                    return Ok();
                }
                return BadRequest("Categoria já existe!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return BadRequest();
                }

                var hasCategory = await _uof.CategoryRepository.GetById(c => c.Name == category.Name);
                if (hasCategory is null)
                {
                    _uof.CategoryRepository.Update(category);
                    await _uof.Commit();

                    return Ok();
                }
                
                return BadRequest("Categoria já existe!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _uof.CategoryRepository.GetById(p => p.CategoryId == id);

                if (category is null)
                {
                    return NotFound();
                }
                _uof.CategoryRepository.Delete(category);
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
