using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private MyDbContext _db;

        public TestController(MyDbContext db)
        {

            _db = db;

        }


        [HttpGet("data")]
        [Authorize]
        public IActionResult GetData()
        {
            return Ok(new { Data = "This is a protected data" });
        }
    }
}
