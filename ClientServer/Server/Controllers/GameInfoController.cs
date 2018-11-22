using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/gameinfo")]
    [ApiController]
    public class GameInfoController : ControllerBase
    {
        private readonly GameInfoContext _context;

        public GameInfoController(GameInfoContext context)
        {
            _context = context;

            if (_context.GameInfos.Count() == 0)
            {
                //sukuriam nauja BlockInGame jei empty, reiskia negalim istrint visu BlockInGames
                _context.GameInfos.Add(new GameInfo { GameTitle = "GameInfo 1" });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<GameInfo>> GetAll()
        {
            return _context.GameInfos.ToList();
        }

        [HttpGet("{id}", Name = "GetGameInfo")]
        public ActionResult<GameInfo> GetById(long id)
        {
            var item = _context.GameInfos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(GameInfo item)
        {
            _context.GameInfos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetGameInfo", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, GameInfo item)
        {
            var todo = _context.GameInfos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            
            todo.GameTitle = item.GameTitle;
            todo.MapId = item.MapId;
            todo.GameTime = item.GameTime;
            todo.Player1Id = item.Player1Id;
            todo.Player2Id = item.Player2Id;
            todo.Player3Id = item.Player3Id;
            todo.Player4Id = item.Player4Id;
            todo.ConnectedPlayersCount = item.ConnectedPlayersCount;
            todo.ResultTableId = item.ResultTableId;
            todo.HasStarted = item.HasStarted;
            todo.HasEnded = item.HasEnded;

            _context.GameInfos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.GameInfos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.GameInfos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
