using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Action Figures" },
            new Category { Id = 2, Name = "Dolls" },
            new Category { Id = 3, Name = "Puzzles" }
        };

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return categories;
        }
    }
}