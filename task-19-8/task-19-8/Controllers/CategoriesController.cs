using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private MyDbContext _db ;

        public CategoriesController(MyDbContext db)
        {

            _db = db;
        }

        
        [HttpGet]
        [Route("Get all categories")]
        public IActionResult Get()
        {
            var cart = _db.Categories.ToList();

            return Ok(cart);
        }


        [HttpGet]   //route method  attribute
        [Route(" Get one categories")]
        public IActionResult Get( [FromQuery]  int id , [FromQuery] string name)
        {
            var data = _db.Categories.Where(c => c.CategoryId == id && c.CategoryName == name).FirstOrDefault();

            return Ok(data);
        }


        


        [HttpGet]
        [Route("Category/OneCategory/{name}")]   // route attribute & parmiter

        public IActionResult GetCategory( string name )
        {
            var data = _db.Categories.Where(c => c.CategoryName == name ).FirstOrDefault();

            return Ok(data);
        }


        [HttpDelete]
        [Route("delete one categories/{Id}")]

        public IActionResult delete(int Id)
        {
            var y = _db.Categories.Find(Id);
            if (y != null)
            {

                _db.Categories.Remove(y);
                _db.SaveChanges();

                return Ok(y);
            }
            return BadRequest();
        }



    }
}
