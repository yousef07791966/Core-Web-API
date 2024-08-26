using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.DTO;
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

        [HttpGet ("Get all users")]
        public IActionResult Get()
        {
            var cart = _db.Users.ToList();

            return Ok(cart);
        }


        [HttpGet("Get one user by id")]
        public IActionResult Get( [FromQuery] int id)
        {
            var data = _db.Users.Where(c => c.UserId == id).FirstOrDefault();

            return Ok(data);
        }

        [HttpGet("Get on user by name")]
        public IActionResult Get(string name )
        {
            var data = _db.Users.Where(c => c.Username == name).ToList();

            return Ok(data);
        }

        [HttpDelete("delete one user by id")]

        public IActionResult delete(int Id)
        {
            var y = _db.Users.FirstOrDefault(c => c.UserId == Id);
            if (y != null)
            {
                _db.Users.Remove(y);
                _db.SaveChanges();

                return Ok(y);
            }
            return BadRequest();
        }



        //////////////////////////////////////
        ///  task 3    <summary>



        [HttpPost]
        public IActionResult getAll([FromForm] user prouctDto)
        {

            var data = new User
            {

                Username = prouctDto.Username,
                Password = prouctDto.Password,
                Email = prouctDto.Email,

            };

            {
                _db.Users.Add(data);
                _db.SaveChanges();

                return Ok("تم التسجيل بنجاح.");
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update([FromForm] user proutDto, int id)
        {
         
            var data = new User

            {
                Username = proutDto.Username,
                Password = proutDto.Password,
                Email = proutDto.Email,
            };

            _db.Users.Update(data);
            _db.SaveChanges();
            return Ok("تم التسجيل بنجاح.");

        }

    }
}
