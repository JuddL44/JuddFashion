using JuddFashion.API.Data;
using JuddFashion.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuddFashion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context) { _context = context; }

        // GET
        [HttpGet] // - /api/products
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Variants).Where(p => p.IsActive).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")] // - /api/products/(id)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Variants).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }



        // POST
        [HttpPost] // - /api/products
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new {id = product.Id }, product);
        }



        // PUT
        [HttpPut("{id}")] // - /api/products/(id)
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }




        // DELETE
        [HttpDelete("{id}")] // - /api/products/(id)
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) { return NotFound(); }

            product.IsActive = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }



        // TOOLS
        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
