using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_19_8.DTO;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private MyDbContext _db;
        private readonly ILogger<UsersController> _logger;

        public UsersController(MyDbContext db, ILogger<UsersController> logger)
        {

            _db = db;
            _logger = logger;
        }

        /// //////////////////////
        ///   </task 2>


        [HttpGet("Get all users")]
        [ProducesResponseType(200, Type = typeof(productDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]



        public IActionResult Get()
        {
            var cart = _db.Users.ToList();

            return Ok(cart);
        }


        //[HttpGet("Get one user by id")]
        //public IActionResult Get( [FromQuery] int id)
        //{
        //    var data = _db.Users.Where(c => c.UserId == id).FirstOrDefault();

        //    return Ok(data);
        //}

        //[HttpGet("Get on user by name")]
        //public IActionResult Get(string name )
        //{
        //    var data = _db.Users.Where(c => c.Username == name).ToList();

        //    return Ok(data);
        //}

        //[HttpDelete("delete one user by id")]

        //public IActionResult delete(int Id)
        //{
        //    var y = _db.Users.FirstOrDefault(c => c.UserId == Id);
        //    if (y != null)
        //    {
        //        _db.Users.Remove(y);
        //        _db.SaveChanges();

        //        return Ok(y);
        //    }
        //    return BadRequest();
        //}



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
        public IActionResult Update([FromForm] user UsertDto, int id)
        {


            var us = _db.Users.FirstOrDefault(x => x.UserId == id);
            if (us != null)
            {


                us.Username = UsertDto.Username;
                us.Password = UsertDto.Password;
                us.Email = UsertDto.Email;
            }

            _db.Users.Update(us);
            _db.SaveChanges();
            return Ok("تم التسجيل بنجاح.");

        }

        /// /////////////
        ///  test 

        [HttpGet("CheckNumbers")]
        public IActionResult CheckNumbers(int num1, int num2)
        {
            bool result = (num1 == 30 || num2 == 30 || (num1 + num2) == 30);

            return Ok(result);
        }


        [HttpGet("CheckMultiple")]
        public IActionResult CheckMultiple(int number)
        {
            bool result = (number > 0) && (number % 3 == 0 || number % 7 == 0);

            return Ok(result);
        }

        /// <summary>
        /// ////////////////
        /// </summary>
        /// <param =login & register> task also</param>
        /// <returns></returns>


        [HttpPost("register")]
        public IActionResult Register([FromForm] UserHashDTO model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                return BadRequest();
            }


            byte[] passwordHash, passwordSalt;
            passwordhash.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            //For Demo Purpose we are returning the PasswordHash and PasswordSalt
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] UserHashDTO model)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null || !passwordhash.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            // Generate a token or return a success response
            return Ok("User logged in successfully");
        }



        [HttpGet("return/info{id}")]

        public IActionResult ReturnInfo(int id ) {

            var user = _db.Users.Where(u => u.UserId == id).ToList();

            return Ok(user);
        }


    }
}