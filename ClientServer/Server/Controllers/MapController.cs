using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/map")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly MapContext _context;

        public MapController(MapContext context)
        {
            _context = context;

            if (_context.Maps.Count() == 0)
            {
                //sukuriam nauja Map jei empty, reiskia negalim istrint visu Maps
                _context.Maps.Add(new Map { Name = "Map 1" });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<Map>> GetAll()
        {
            return _context.Maps.ToList();
        }

        [HttpGet("{id}", Name = "GetMap")]
        public ActionResult<Map> GetById(long id)
        {
            var item = _context.Maps.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(Map item)
        {
            _context.Maps.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMap", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, Map item)
        {
            var todo = _context.Maps.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = item.Name;
            todo.Blocks = item.Blocks;

            _context.Maps.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Maps.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Maps.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
