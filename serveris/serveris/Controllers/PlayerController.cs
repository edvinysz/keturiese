using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using serveris.Models;
using Microsoft.AspNetCore.Mvc;

namespace serveris.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;

            if (_context.Players.Count() == 0)
            {
                //sukuriam nauja serverisItem jei empty, reiskia negalim istrint visu serverisItems
                _context.Players.Add(new Player { Username = "P1" });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return _context.Players.ToList();
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public ActionResult<Player> GetById(long id)
        {
            var item = _context.Players.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(Player item)
        {
            _context.Players.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPlayer", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, Player item)
        {
            var todo = _context.Players.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Username = item.Username;
            todo.PositionX = item.PositionX;
            todo.PositionY = item.PositionY;
            todo.DeathCount = item.DeathCount;

            _context.Players.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Players.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Players.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
