using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            var cart = _db.Orders.ToList();

            return Ok(cart);
        }

        [HttpGet("OrderId")]
        public IActionResult Get(int id)
        {
            var d = _db.Orders.Where(c => c.OrderId == id).ToList();

            return Ok(d);
        }

        //[HttpGet("OrderName")]
        //public IActionResult Get(int id)
        //{
        //    var d = _db.Orders.Where(c => c.OrderDate == id).ToList();

        //    return Ok(d);
        //}


        [HttpDelete("{Id}")]

        public IActionResult delete(int Id)
        {
            var y = _db.Orders.FirstOrDefault(c => c.OrderId == Id);

            _db.Orders.Remove(y);
            _db.SaveChanges();

            return Ok(y);
        }
    }
}
