using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/block")]
    [ApiController]
    public class BlockInGameController : ControllerBase
    {
        private readonly BlockInGameContext _context;

        public BlockInGameController(BlockInGameContext context)
        {
            _context = context;

            if (_context.BlocksInGame.Count() == 0)
            {
                //sukuriam nauja BlockInGame jei empty, reiskia negalim istrint visu BlockInGames
              //  _context.BlocksInGame.Add(new BlockInGame { Name = "Block 1" });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<BlockInGame>> GetAll()
        {
            return _context.BlocksInGame.ToList();
        }

        [HttpGet("{id}", Name = "GetBlock")]
        public ActionResult<BlockInGame> GetById(long id)
        {
            var item = _context.BlocksInGame.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(BlockInGame item)
        {
            _context.BlocksInGame.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBlock", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, BlockInGame item)
        {
            var todo = _context.BlocksInGame.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.BlockId = item.BlockId;
            todo.IsFinish = item.IsFinish;
            todo.GiveDamage = item.GiveDamage;
            todo.PositionId = item.PositionId;
            todo.Name = item.Name;
            todo.ImageId = item.ImageId;
            todo.Type = item.Type;
            todo.Width = item.Width;
            todo.Height = item.Height;

            _context.BlocksInGame.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.BlocksInGame.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.BlocksInGame.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
