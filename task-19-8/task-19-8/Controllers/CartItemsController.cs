using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.DTO;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {


        private MyDbContext _db;

        public CartItemsController(MyDbContext db)
        {

            _db = db;

        }



        /// ///////////////
        /// task 4

        [HttpGet]

        public IActionResult GetAllData(int id)
        {

            var getData = _db.CartItems.Where(c => c.CartId == id).Select(x =>
            new cateItemResponseDTO
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new productDTO
                {
                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,


                }


            }

                ).ToList();

            return Ok(getData);
        }

        [HttpPost("postData/to/cart")]

        public IActionResult GetDatapost([FromBody] addCarteItem cart)
        {
            var data = new CartItem
            {
                Quantity = cart.Quantity,
                ProductId = cart.ProductId,
                CartId = cart.CartId,

            };

            _db.CartItems.Add(data);
            _db.SaveChanges();

            return Ok(data);
        }


        //////////////////////////////
        ///
        [HttpGet("get/all/cart")]

        public IActionResult GetAllCarts()
        {

            var getData = _db.CartItems.Select(x =>
            new cateItemResponseDTO
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new productDTO
                {
                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,


                }
            }

                ).ToList();

            return Ok(getData);
        }




        [HttpPut("update/quantity/{id}")]
        public IActionResult Update([FromBody] QuantityDTO QuDTO, int id)
        {


            var c = _db.CartItems.Find(id);
        
            c.Quantity = QuDTO.Quantity;
            
            
                _db.CartItems.Update(c);
                _db.SaveChanges();
                return Ok("thank you");

            
            
         
        }

        [HttpDelete("delete/one/{id}")]
        public IActionResult Delete(int id)
        {

            var delet = _db.CartItems.FirstOrDefault();
            
                _db.CartItems.Remove(delet);
                _db.SaveChanges();


                return Ok(delet);
            
        }




    }
}
