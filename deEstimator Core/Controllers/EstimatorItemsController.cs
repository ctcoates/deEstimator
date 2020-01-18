using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deEstimator_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace deEstimator_Core.Controllers
{
    [Route("api/[controller]")]
    public class EstimatorItemController : Controller
    {
        private readonly EstimatorItemContext _context;

        public EstimatorItemController(EstimatorItemContext context)
        {
            _context = context;

            if (_context.EstimatorItems.Count() == 0)
            {
                _context.EstimatorItems.Add(new EstimatorItem { Description = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<EstimatorItem> GetAll()
        {
            return _context.EstimatorItems.ToList();
        }

        [HttpGet("{id}", Name = "GetEstimatorItem")]
        public IActionResult GetById(long id)
        {
            var item = _context.EstimatorItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EstimatorItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.EstimatorItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEstimatorItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.EstimatorItems.First(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.EstimatorItems.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}