using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly QL_SachContext _context;
        public BookController(QL_SachContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var model = _context.Books.ToList();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var target = _context.Books.Where(c=>c.Id==id).FirstOrDefault();
            return Ok(target);
        }
        [HttpPost]
        public IActionResult Create([FromBody]Book model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.Books.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Book model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _context.Books.Find(id);
            if (product == null)
            {
                return NotFound();
            }
             _context.Entry(product).CurrentValues.SetValues(model);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Books.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}