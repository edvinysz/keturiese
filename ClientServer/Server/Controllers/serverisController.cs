using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/Server")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ServerContext _context;

        public ServerController(ServerContext context)
        {
            _context = context;

            if (_context.ServerItems.Count() == 0)
            {
                //sukuriam nauja ServerItem jei empty, reiskia negalim istrint visu ServerItems
                _context.ServerItems.Add(new ServerItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
         

        // GET METODAS
        [HttpGet]
        public ActionResult<List<ServerItem>> GetAll()
        {
            return _context.ServerItems.ToList();
        }

        [HttpGet("{id}", Name = "GetServer")]
        public ActionResult<ServerItem> GetById(long id)
        {
            var item = _context.ServerItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(ServerItem item)
        {
            _context.ServerItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetServer", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, ServerItem item)
        {
            var todo = _context.ServerItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.ServerItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.ServerItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.ServerItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
