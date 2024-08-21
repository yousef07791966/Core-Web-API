using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private MyDbContext _db;

        public UsersController(MyDbContext db)
        {

            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cart = _db.Users.ToList();

            return Ok(cart);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _db.Users.Where(c => c.UserId == id).ToList();

            return Ok(data);
        }

        [HttpGet("/name/{name}")]
        public IActionResult Get(string name)
        {
            var data = _db.Users.Where(c => c.Username == name).ToList();

            return Ok(data);
        }

        [HttpDelete("{Id}")]

        public IActionResult delete(int Id)
        {
            var y = _db.Users.FirstOrDefault(c => c.UserId == Id);

            _db.Users.Remove(y);
            _db.SaveChanges();

            return Ok(y);
        }

    }
}
