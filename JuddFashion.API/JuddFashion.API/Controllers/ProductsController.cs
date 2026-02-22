using AutoMapper;
using JuddFashion.API.Data;
using JuddFashion.API.Models;
using JuddFashion.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JuddFashion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET
        [HttpGet] // - /api/products
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Variants).Where(p => p.IsActive).ToListAsync();
            var productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productDTOs);
        }

        [HttpGet("{id}")] // - /api/products/(id)
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Variants).FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            if (product == null) { return NotFound(); }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        [HttpGet("category/{category}")] // - /api/products/category/(category)
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategory(ClothingCategory category)
        {
            var products = await _context.Products.Include(p => p.Variants).Where(p => p.Category == category && p.IsActive).ToListAsync();
            var productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productDTOs);
        }

        [HttpGet("search")] // - /api/products/search?query=(query)&category=(category)&sortBy=(sortBy)
        public async Task<ActionResult<IEnumerable<ProductDTO>>> SearchProducts([FromQuery] string? query, [FromQuery] ClothingCategory? category, [FromQuery] string? sortBy) {

            var productsQuery = _context.Products.Include(p => p.Variants).Where(p => p.IsActive);
            
            if (!string.IsNullOrWhiteSpace(query))
            {
                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(query.ToLower()) ||
                    p.Description.ToLower().Contains(query.ToLower()) ||
                    p.Brand.ToLower().Contains(query.ToLower())
                );
            }

            if (category.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Category == category.Value);
            }

            productsQuery = sortBy?.ToLower() switch
            {
                "price_asc" => productsQuery.OrderBy(p => p.BasePrice),
                "price_desc" => productsQuery.OrderByDescending(p => p.BasePrice),
                "name" => productsQuery.OrderBy(p => p.Name),
                "newest" => productsQuery.OrderByDescending(p => p.DateAdded),
                _ => productsQuery.OrderBy(p => p.Id)
            };

            var products = await productsQuery.ToListAsync();
            var productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productDTOs);
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
