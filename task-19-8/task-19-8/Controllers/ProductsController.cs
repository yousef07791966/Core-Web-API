using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private MyDbContext _db;

        public ProductsController(MyDbContext db)
        {

            _db = db;   
        }


        //[HttpGet]

        //public IActionResult Get()
        //{
        //    var cart = _db.Products.ToList();

        //    return Ok(cart);
        //}

        //[HttpGet("ProductId")]

        //public IActionResult Get(int ProductId)
        //{
        //    var data = _db.Products.Where(c => c.ProductId == ProductId ).ToList();

        //    return Ok(data);
        //}

        //[HttpGet("{ProductId}/{price}")]

        //public IActionResult Get(int CategoryId, int price)
        //{
        //    var data = _db.Products.Where(c => c.CategoryId == CategoryId && c.Price > 100).Count();

        //    return Ok(data);
        //}

        //public IActionResult Get(int ProductId)
        //{
        //    var data = _db.Products.Where(c => c.ProductId == ProductId).ToList();

        //    return Ok(data);
        //}


        //[HttpGet("{id:int}")]

        //public IActionResult Getid(int id)
        //{

        //    var product = _db.Products.FirstOrDefault(y => y.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        //[HttpGet("{name:alpha}")]
        //public IActionResult Getproduct(string name)
        //{

        //    var pro = _db.Products.Where(b => b.ProductName == name);
        //    return Ok(pro);

        //}





        //[HttpDelete("{Id}")]

        //public IActionResult delete(int Id)
        //{
        //    var r = _db.Products.FirstOrDefault(c => c.ProductId == Id);


        //    _db.Products.Remove(r);

        //    _db.SaveChanges();


        //    return Ok(r);
        //}

        //[Route("product/{Id}")] 
        //[HttpGet]
        //public IActionResult productID(int Id )
        //{
        //    var pro = _db.Products.Where(x => x.ProductId == Id).FirstOrDefault();

        //    if (pro != null)
        //    {
        //        return Ok();

        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    var you = _db.Products.FirstOrDefault(c => c.ProductId == id);
        //    if (you == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Products.Remove(you);

        //    _db.SaveChanges();
        //    return Ok(you);
        //}

        //[HttpGet(" Get One Product/ by id max value (5) {id:int:minlength(5)}")] /// force in console to update database

        //public IActionResult GetProducts(int id)
        //{
        //    var data = _db.Products.Where(c => c.ProductId == id).ToList();

        //    return Ok(data);
        //}

        //[HttpGet(" Get One Product/ by id max value (5) {id:int:regex(502)}")] /// force in console to update database

        //public IActionResult GetProducts(int id)
        //{
        //    var data = _db.Products.Where(c => c.ProductId == id).ToList();

        //    return Ok(data);
        //}

        //[HttpGet(" Get One Product/ by id max value (5) {id:int:range(10-15)}")] /// force in console to update database

        //public IActionResult GetProducts(int id)
        //{
        //    var data = _db.Products.Where(c => c.ProductId == id).ToList();

        //    return Ok(data);
        //}


        //[HttpGet("api/Products/{name}")]
        //[HttpGet("api/Products/{id:int}")]

        //public IActionResult GetProduct(int id, string? name)

        //{
        //    if (id > 0)
        //    {
        //        var products = _db.Products.FirstOrDefault(f => f.ProductId == id);

        //        return Ok(products);
        //    }

        //    else if (!string.IsNullOrEmpty(name))
        //    {
        //        var products = _db.Products.FirstOrDefault(f => f.ProductName == name);

        //        return Ok(products);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }


        //}



        //////////////////////////////////////////////////////////////////////////
        /// task

        [HttpGet]
        [Route("Get all Products")]

        public IActionResult Get()
        {
            var cart = _db.Products.ToList();

            return Ok(cart);
        }

        [HttpGet]
        [Route("Get one Product / by {id}")]

        public IActionResult Get([FromQuery] int id)
        {
            var data = _db.Products.Where(c => c.ProductId == id).ToList();

            return Ok(data);
        }

        [HttpGet(" Get One Product/ by id max value (5) {id:int:max(5)}")] /// force in console to update database

        public IActionResult GetProducts(int id)
        {
            var data = _db.Products.Where(c => c.ProductId == id).ToList();

            return Ok(data);
        }



        [HttpDelete]
        [Route(" delete one Product{Id}")]

        public IActionResult delete(int Id)
        {
            var y = _db.Products.FirstOrDefault(c => c.ProductId == Id);

            _db.Products.Remove(y);
            _db.SaveChanges();

            return Ok(y);
        }

    }

}
