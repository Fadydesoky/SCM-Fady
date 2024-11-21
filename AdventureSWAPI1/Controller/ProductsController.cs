using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureSWAPI.Models;  // Add your model namespace here

namespace AdventureSWAPI.Controllers
{
    [Route("api/[controller]")]  // URL pattern for the controller (e.g., /api/products)
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;  // The database context to interact with DB

        // Constructor: Injecting the database context
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;  // Storing the injected context
        }

        // GET: api/products
        // This action will retrieve all products from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Fetches all products from the database
            var products = await _context.Products.ToListAsync();
            return Ok(products);  // Returns a 200 OK response with the list of products
        }

        // GET: api/products/5
        // This action will retrieve a single product by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);  // Find a product by ID

            if (product == null)
            {
                return NotFound();  // If no product found, return a 404 Not Found response
            }

            return Ok(product);  // If product found, return it with a 200 OK response
        }

        // POST: api/products
        // This action will create a new product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);  // Adds the product to the context
            await _context.SaveChangesAsync();  // Saves the changes to the database

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);  // Return a 201 Created response with the product
        }

        // PUT: api/products/5
        // This action will update an existing product by its ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();  // If IDs don't match, return a 400 Bad Request response
            }

            _context.Entry(product).State = EntityState.Modified;  // Mark the product as modified
            await _context.SaveChangesAsync();  // Save the changes to the database

            return NoContent();  // Return a 204 No Content response, indicating the update was successful
        }

        // DELETE: api/products/5
        // This action will delete a product by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);  // Find the product by ID

            if (product == null)
            {
                return NotFound();  // If no product found, return 404 Not Found response
            }

            _context.Products.Remove(product);  // Remove the product from the context
            await _context.SaveChangesAsync();  // Save changes to the database

            return NoContent();  // Return a 204 No Content response, indicating deletion was successful
        }
    }
}