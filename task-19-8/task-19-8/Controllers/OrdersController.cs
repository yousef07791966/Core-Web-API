using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private MyDbContext _db;

        public OrdersController(MyDbContext db)
        {

            _db = db;
        }

        [HttpGet("Get all Orders")]
        public IActionResult Get()
        {
            var cart = _db.Orders.ToList();

            return Ok(cart);
        }




        [HttpGet("Get one Order / by id")]
        public IActionResult Get([FromQuery] int id)

        {
            if (id > 0)
            {
                var d = _db.Orders.Where(c => c.OrderId == id).ToList();

                return Ok(d);
            }
            return BadRequest();
        }

        [HttpGet("Get one Order / by date")]
        public IActionResult Get([FromQuery] int year , [FromQuery] int month , [FromQuery] int day )
        {

            var y = new DateOnly(year, month, day); 
            var d = _db.Orders.Where(c => c.OrderDate == y).ToList();
             
            return Ok(d);
        }


        [HttpDelete("delete one Order ")]

        public IActionResult delete([FromQuery] int Id)
        {

            var y = _db.Orders.FirstOrDefault(c => c.OrderId == Id);
            if (y != null)
            {
                _db.Orders.Remove(y);
                _db.SaveChanges();


                return Ok(y);
            }
            return BadRequest();

        }
       
    }
}
