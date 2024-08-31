using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using task_19_8.DTO;
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

        public IActionResult GetAllData()
        {

           var getData = _db.Categories.ToList();

            return Ok (getData);
        }






        [HttpGet]

        [Route("{id:int}")]

        public IActionResult GetData([FromQuery] int id)
        {

            var get = _db.Categories.Where(cat => cat.CategoryId == id).FirstOrDefault();

            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var delet = _db.Categories.FirstOrDefault();
            if (delet != null)
            {
                _db.Categories.Remove(delet);
                _db.SaveChanges();


                return Ok(delet);
            }
            return BadRequest();
        }




        //////////////////////////////////////////////////////////////
        /// task 2
        /// 




        [HttpGet]
        [Route("Get all categories")]
        public IActionResult Get()
        {
            var cart = _db.Categories.ToList();

            return Ok(cart);
        }


        [HttpGet]   //route method  attribute
        [Route(" Get one categories")]
        public IActionResult Get([FromQuery] int id, [FromQuery] string name)
        {
            var data = _db.Categories.Where(c => c.CategoryId == id && c.CategoryName == name).FirstOrDefault();

            return Ok(data);
        }





        [HttpGet]
        [Route("Category/OneCategory/{name}")]   // route attribute & parmiter

        public IActionResult GetCategory(string name)
        {
            var data = _db.Categories.Where(c => c.CategoryName == name).FirstOrDefault();

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




        ///////////////////////////////////////////
        ///  task 3    <summary>



        [HttpPost]
        public IActionResult Register([FromForm] categ categDto)
        {

            var category = new Category(); /// بدي ارجع افهم 

            category.CategoryName = categDto.CategoryName;
            category.CategoryImage = categDto.CategoryImage?.FileName;

            _db.Categories.Add(category);
            _db.SaveChanges();

            return Ok("تم التسجيل بنجاح.");
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromForm] categ categDto, int id)
        {
            if (categDto.CategoryImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, categDto.CategoryImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    categDto.CategoryImage.CopyToAsync(stream);
                }

            }

            var c = _db.Categories.FirstOrDefault(l => l.CategoryId == id);
            c.CategoryName = categDto.CategoryName;
            c.CategoryImage = categDto.CategoryImage.FileName;

            _db.Categories.Update(c);
            _db.SaveChanges();
            return Ok();

        }
    }

 }







