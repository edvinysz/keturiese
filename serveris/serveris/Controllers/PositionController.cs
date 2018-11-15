using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serveris.Models;

namespace serveris.Controllers
{
    [Route("api/position")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionContext _context;

        public PositionController(PositionContext context)
        {
            _context = context;

            if (_context.Positions.Count() == 0)
            {
                //sukuriam nauja Position jei empty, reiskia negalim istrint visu Positions
                _context.Positions.Add(new Position { PositionX = 0, PositionY = 0 });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<Position>> GetAll()
        {
            return _context.Positions.ToList();
        }

        [HttpGet("{id}", Name = "GetPosition")]
        public ActionResult<Position> GetById(long id)
        {
            var item = _context.Positions.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(Position item)
        {
            _context.Positions.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPosition", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, Position item)
        {
            var todo = _context.Positions.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.PositionX = item.PositionX;
            todo.PositionY = item.PositionY;

            _context.Positions.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Positions.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
