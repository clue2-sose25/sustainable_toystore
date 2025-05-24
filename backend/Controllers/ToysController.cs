using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToysController : ControllerBase
    {
        private static List<Toy> toys = new List<Toy>
        {
            new Toy { Id = 1, Name = "Superman Figure", CategoryId = 1 },
            new Toy { Id = 2, Name = "Barbie Doll", CategoryId = 2 },
            new Toy { Id = 3, Name = "Jigsaw Puzzle", CategoryId = 3 }
        };

        [HttpGet]
        public ActionResult<List<Toy>> Get()
        {
            return toys;
        }

        [HttpGet("{id}")]
        public ActionResult<Toy> Get(int id)
        {
            var toy = toys.FirstOrDefault(t => t.Id == id);
            if (toy == null)
            {
                return NotFound();
            }
            return toy;
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<Toy>> GetByCategory(int categoryId)
        {
            var categoryToys = toys.Where(t => t.CategoryId == categoryId).ToList();
            return categoryToys;
        }
    }
}