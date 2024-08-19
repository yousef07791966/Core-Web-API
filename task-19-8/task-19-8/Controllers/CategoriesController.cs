using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private MyDbContext _db;

        public CategoriesController(MyDbContext db)
        {

            _db = db;
        }


        [HttpGet]

        public IActionResult Get()
        {
            var cart = _db.Categories.ToList();

            return Ok(cart);
        }

        [HttpGet("CategoryId")]

        public IActionResult Get(int id)
        {
            var data = _db.Categories.Where(c => c.CategoryId == id && c.CategoryId == id).ToList();

            return Ok(data);
        }

    }
}
