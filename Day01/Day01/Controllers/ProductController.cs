using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day01.Data.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Day01.ViewModels;
using Microsoft.EntityFrameworkCore;
using Day01.Models;
namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Appcontext db = new Appcontext();

        [HttpGet]
        public IActionResult Index()
        {
            var AllData = db.Products.Include(o=>o.Category).Select(p => new ProductVM
            {
                Title = p.Title,
                Description = p.Description,
                Count = p.Count,
                Price = p.Price,
                Category = p.Category.Name
            });
            return Ok(AllData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID(int id)
        {
            var res = db.Products.Include(o=>o.Category).FirstOrDefault(p => p.Id == id);
            if (res == null)
                return NotFound();
            var Data = new ProductVM
            {
                Title = res.Title,
                Description = res.Description,
                Count = res.Count,
                Price = res.Price,
                Category = res.Category.Name
            };

            return Ok(Data);
        }

        [HttpPost]
       public IActionResult AddNewProduct(ProductAddVM _product)
        {
            var DbData = new Product
            {
              
                Title = _product.Title,
                Description = _product.Description,
                Count = _product.Count,
                Price = _product.Price,
                CategoryId = _product.CategId
            };
            db.Products.Add(DbData);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetByID), new { id = DbData.Id }, new { Message = "Product Added Successfully" });
        }

        [HttpPut]
            [Route("{id}")]
    public IActionResult UpdateProduct(int id, ProductAddVM _product)
     {
            var res = db.Products.FirstOrDefault(i => i.Id == id);
            if (res == null)
                return NotFound();
            res.Title = _product.Title;
            res.Description = _product.Description;
            res.CategoryId = _product.CategId;
            res.Count = _product.Count;
            res.Price = _product.Price;
            db.SaveChanges();
            return NoContent();

     }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var res = db.Products.FirstOrDefault(i => i.Id == id);
            if (res == null)
                return BadRequest();
            db.Products.Remove(res);
            db.SaveChanges();
                return Ok();
        }

    }
}
