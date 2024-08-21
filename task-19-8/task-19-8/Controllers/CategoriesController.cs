﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult Get()
        {
            var cart = _db.Categories.ToList();

            return Ok(cart);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _db.Categories.Where(c => c.CategoryId == id).ToList();

            return Ok(data);
        }


        [HttpGet]
        [Route("Category/OneCategory/{id:int:min(5)}")]

        public IActionResult GetCategory(int id)
        {
            var data = _db.Categories.Where(c => c.CategoryId == id).ToList();

            return Ok(data);
        }


        [HttpDelete("{Id}")]

        public IActionResult delete(int Id)
        {
            var y = _db.Categories.FirstOrDefault(c => c.CategoryId == Id);

            _db.Categories.Remove(y);
            _db.SaveChanges();

            return Ok(y);
        }



    }
}
