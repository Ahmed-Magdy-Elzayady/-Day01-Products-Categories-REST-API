using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day01.Data.Context;
using Day01.ViewModels;
using Day01.Models;
namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        Appcontext db = new Appcontext();
        [HttpGet]
        public IActionResult Index()
        {

            var AllData = db.Categories.Select(p => new CategoryVM
            {
                Id = p.Id,
                Name = p.Name
            });
            return Ok(AllData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var res = db.Categories.FirstOrDefault(i => i.Id == id);
            var Data = new CategoryVM
            {
                Id = res.Id,
                Name = res.Name
            };
            return Ok(Data);
        }

        [HttpPost]
        public IActionResult AddNewCategory(CategoryAddVM _category)
        {
            var Data = new Category
            {
                Name = _category.Name
            };

            db.Categories.Add(Data);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = Data.Id }, new { Message = "Category Added Successfully" });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCategory(int id, CategoryAddVM _category)
        {
            var res = db.Categories.FirstOrDefault(i => i.Id == id);
            if (res == null)
                return NotFound();
            res.Name =_category.Name;
            db.SaveChanges();
            return NoContent();

        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var res = db.Categories.FirstOrDefault(i => i.Id == id);
            if (res == null)
                return BadRequest();
            db.Categories.Remove(res);
            db.SaveChanges();
            return Ok();
        }
    }
}
