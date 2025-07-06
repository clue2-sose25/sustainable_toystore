using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTOs;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToysController : ControllerBase
    {
        private readonly ToyStoreContext _context;

        public ToysController(ToyStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToyDto>>> Get()
        {
            var toys = await _context.Toys.Include(t => t.Category).ToListAsync();
            var toyDtos = toys.Select(t => new ToyDto
            {
                Id = t.Id,
                Name = t.Name,
                CategoryId = t.CategoryId,
                Category = new CategoryDto
                {
                    Id = t.Category.Id,
                    Name = t.Category.Name
                }
            }).ToList();

            return Ok(toyDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToyDto>> Get(int id)
        {
            var toy = await _context.Toys.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
            if (toy == null)
            {
                return NotFound();
            }

            var toyDto = new ToyDto
            {
                Id = toy.Id,
                Name = toy.Name,
                CategoryId = toy.CategoryId,
                Category = new CategoryDto
                {
                    Id = toy.Category.Id,
                    Name = toy.Category.Name
                }
            };

            return Ok(toyDto);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<ToyDto>>> GetByCategory(int categoryId)
        {
            var categoryToys = await _context.Toys
                .Where(t => t.CategoryId == categoryId)
                .Include(t => t.Category)
                .ToListAsync();

            var toyDtos = categoryToys.Select(t => new ToyDto
            {
                Id = t.Id,
                Name = t.Name,
                CategoryId = t.CategoryId,
                Category = new CategoryDto
                {
                    Id = t.Category.Id,
                    Name = t.Category.Name
                }
            }).ToList();

            return Ok(toyDtos);
        }

        [HttpPost]
        public async Task<ActionResult<ToyDto>> Post(Toy toy)
        {
            // Validate that the category exists
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == toy.CategoryId);
            if (!categoryExists)
            {
                return BadRequest("Invalid CategoryId");
            }

            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();

            // Reload the toy with category information
            var createdToy = await _context.Toys.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == toy.Id);
            if (createdToy != null)
            {
                var toyDto = new ToyDto
                {
                    Id = createdToy.Id,
                    Name = createdToy.Name,
                    CategoryId = createdToy.CategoryId,
                    Category = new CategoryDto
                    {
                        Id = createdToy.Category.Id,
                        Name = createdToy.Category.Name
                    }
                };
                return CreatedAtAction(nameof(Get), new { id = toy.Id }, toyDto);
            }

            return BadRequest("Failed to create toy");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Toy toy)
        {
            if (id != toy.Id)
            {
                return BadRequest();
            }

            // Validate that the category exists
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == toy.CategoryId);
            if (!categoryExists)
            {
                return BadRequest("Invalid CategoryId");
            }

            _context.Entry(toy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToyExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toy = await _context.Toys.FindAsync(id);
            if (toy == null)
            {
                return NotFound();
            }

            _context.Toys.Remove(toy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToyExists(int id)
        {
            return _context.Toys.Any(e => e.Id == id);
        }
    }
}